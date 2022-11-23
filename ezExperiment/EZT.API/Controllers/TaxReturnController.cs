using Microsoft.AspNetCore.Mvc;
using EZT.API.Message;
using System.Text.Json;
using System.Text.RegularExpressions;
using static System.Collections.Specialized.BitVector32;
using System.Data;
using EZT.Model;
using System.Data.Common;
using EZT.Data.Service;
using Microsoft.AspNetCore.Http;

namespace EZT.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TaxReturnController : ControllerBase
{

    private readonly ILogger<TaxReturnController> _logger;
    private readonly IDataService _dataService;

    public TaxReturnController(ILogger<TaxReturnController> logger, IDataService dataService)
    {
        _logger = logger;
        this._dataService = dataService;
    }

    [HttpPost]
    [Route("AddOrUpdateFormDefinition")]
    public FormDefinition AddFormDefinition([FromBody] FormDefinition request)
    {
        var formDefJson = JsonSerializer.Serialize(request);
        this._dataService.AddFormDefinition(request.FormName, formDefJson);
        return request;
    }

    [HttpGet]
    [Route("GetFormDefinition/{formName}")]
    public string GetFormDefinition(string formName)
    {
        return this._dataService.GetFormDefinition(formName);
    }

    [HttpPost]
    [Route("AddOrUpdateFilterRecord")]
    public AddOrUpdateFilterRecordResponse AddOrUpdateFilterRecord([FromBody] AddOrUpdateFilterRecordRequest request)
    {
        var filerRecordId = "2022111919";
        request.DataRecordSchema.DataRecordId = filerRecordId;
        var json = JsonSerializer.Serialize(request.DataRecordSchema);

        this._dataService.SaveFilerRecord(filerRecordId, json);

        return new AddOrUpdateFilterRecordResponse
        {
            CustomerId = request.CustomerId,
            FilerRecordId = filerRecordId,
            DataRecordJson = json
        };
    }

    [HttpPost]
    [Route("UpdateDatafields")]
    public FilerRecord UpdateDatafields([FromBody] UpdateDatafieldsRequest request)
    {
        var filerRecordId = request.FilerRecordId;
        var filerRecordJson = this._dataService.GetFilerRecord(filerRecordId);
        var filerRecord = JsonSerializer.Deserialize<FilerRecord>(filerRecordJson);

        foreach (var f in request.DataFieldsToUpdate)
        {
            foreach (var section in filerRecord.Sections)
            {
                foreach (var dataField in section.DataFields)
                {
                    if (!dataField.FieldBinding.Equals(f.FieldBinding))
                        continue;
                    dataField.FieldValue = f.FieldValue;
                }
            }
        }

        filerRecordJson = JsonSerializer.Serialize(filerRecord);
        this._dataService.SaveFilerRecord(filerRecordId, filerRecordJson);
        return filerRecord;
    }

    [HttpGet]
    [Route("GetFilerRecord/{filerRecordId}")]
    public string GetFilerRecord(string filerRecordId)
    {
        return this._dataService.GetFilerRecord(filerRecordId);
    }

    [HttpGet]
    [Route("GetDataForForm/{formName}/{filerRecordId}")]
    public FormDefinition GetDataForForm(string formName, string filerRecordId)
    {
        var formDefJson = this._dataService.GetFormDefinition(formName);
        var filerRecJson = this._dataService.GetFilerRecord(filerRecordId);

        var formDefinition = JsonSerializer.Deserialize<FormDefinition>(formDefJson);
        var filerRecord = JsonSerializer.Deserialize<FilerRecord>(filerRecJson);

        this.MapDataValue(formDefinition, filerRecord);

        return formDefinition;
    }

    private void MapDataValue(FormDefinition formDefinition, FilerRecord filerRecord)
    {
        var values = this.ExtractDataValuesFromFilerRecord(filerRecord);
        foreach (var fieldDef in formDefinition.FieldDefs)
        {
            fieldDef.FieldValue = values[fieldDef.Datamapping];
        }
    }

    private Dictionary<string, string> ExtractDataValuesFromFilerRecord(FilerRecord filerRecord)
    {
        var dict = new Dictionary<string, string>();

        foreach (var section in filerRecord.Sections)
        {
            foreach (var field in section.DataFields)
            {
                dict.Add(string.Format("{0}.{1}", section.SectionName, field.FieldName), field.FieldValue);
            }
        }

        return dict;
    }

    [HttpPost]
    [Route("ExecuteCalculation")]
    public Calculation ExecuteCalculation([FromBody] ExecuteCalculationRequest request)
    {
        var calculation = request.Calculation;

        var filerRecordId = "2022111919";
        var filerRecJson = this._dataService.GetFilerRecord(filerRecordId);
        var filerRecord = JsonSerializer.Deserialize<FilerRecord>(filerRecJson);
        var dict = this.ExtractDataValuesFromFilerRecord(filerRecord);

        var regex = new Regex("(?<=\\{\\{)(\\w+\\.\\w+.*?)(?=\\}\\})");
        var matches = regex.Matches(request.Calculation.CalculationExpression);

        var replaced = calculation.CalculationExpression;

        foreach (Match match in matches)
        {
            var stringValue =
            replaced = replaced.Replace("{{" + match + "}}", dict[match.Value]);
        }

        calculation.ExpressionToExecute = replaced;
        var dt = new DataTable();
        calculation.CalculatedValue = this.ExecuteExpression(calculation.ExpressionToExecute);
        return calculation;
    }

    private string ExecuteExpression(string expression)
    {
        var dt = new DataTable();
        return string.Format("{0}", dt.Compute(expression, ""));
    }
}