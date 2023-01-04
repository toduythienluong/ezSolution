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
public class DemoController : ControllerBase
{

    private readonly ILogger<TaxReturnController> _logger;
    private readonly IDataService _dataService;
    private readonly IEndpointService _endpointService;

    public DemoController(ILogger<TaxReturnController> logger, IDataService dataService, IEndpointService endpointService)
    {
        _logger = logger;
        this._dataService = dataService;
        this._endpointService = endpointService;
    }

    [HttpPost]
    [Route("form")]
    public object AddForm([FromBody] DemoForm formDef)
    {
        var formDefJson = JsonSerializer.Serialize(formDef);
        this._dataService.AddForm(formDef.FormId, formDefJson);
        return new
        {
            formId = formDef.FormId,
            link = this._endpointService.GetFormDefinitionUrl(formDef.FormId)
        };
    }

    [HttpPut]
    [Route("form")]
    public object UpdateForm([FromBody] DemoForm formDef)
    {
        var formDefJson = JsonSerializer.Serialize(formDef);
        this._dataService.AddForm(formDef.FormId, formDefJson);
        return new
        {
            formId = formDef.FormId,
            link = this._endpointService.GetFormDefinitionUrl(formDef.FormId)
        };
    }

    [HttpGet]
    [Route("form/{formId}")]
    public DemoForm AddForm(string formId)
    {

        var formJson = this._dataService.GetFormById(formId);
        var form = JsonSerializer.Deserialize<DemoForm>(formJson);
        return form;
    }

    [HttpPost]
    [Route("filer-record")]
    public DemoFilerRecord AddOrUpdateFilterRecord([FromBody] DemoFilerRecord filerRecord)
    {
        var filerId = filerRecord.FilerId;
        var json = JsonSerializer.Serialize(filerRecord);

        this._dataService.SaveFilerRecord(filerId, json);
        return filerRecord;
    }

    [HttpGet]
    [Route("filer-record/{filerId}")]
    public DemoFilerRecord GetFilerRecord(string filerId)
    {
        var recordJson = this._dataService.GetFilerRecord(filerId);
        var filerRecord = JsonSerializer.Deserialize<DemoFilerRecord>(recordJson);
        return filerRecord;
    }

    [HttpPost]
    [Route("filer-record/{filerId}/field")]
    public DemoFilerRecord UpdateDataField([FromRoute] string filerId, [FromBody] AddNewFieldRequest request)
    {
        var recordJson = this._dataService.GetFilerRecord(filerId);
        var filerRecord = JsonSerializer.Deserialize<DemoFilerRecord>(recordJson);

        var section = filerRecord.Sections.FirstOrDefault(s => s.SectionId.Equals(request.SectionId));
        if (section == null)
            return null;

        section.DataFields.Add(request.DataField);

        var json = JsonSerializer.Serialize(filerRecord);

        this._dataService.SaveFilerRecord(filerId, json);

        return filerRecord;
    }

    [HttpPost]
    [Route("form/{formId}/execution")]
    public object ExecuteForm([FromRoute] string formId, [FromBody] FormExecutionRequest request)
    {
        var formJson = this._dataService.GetFormById(formId);
        var form = JsonSerializer.Deserialize<DemoForm>(formJson);

        var calculationFields = form.FieldDefs.Where(f => f.InputType.Equals("calculation")).ToList();
        foreach (var field in calculationFields)
        {
            var regex = new Regex("(?<=\\{\\{)(\\w+\\w+.*?)(?=\\}\\})");
            var matches = regex.Matches(field.CalculationExpression);
            var replaced = field.CalculationExpression;

            foreach (Match match in matches)
            {
                replaced = replaced.Replace("{{" + match + "}}", request.Parameters[match.Value]);
            }

            var expressionToExecute = replaced;
            var dt = new DataTable();
            field.FieldValue = this.ExecuteExpression(expressionToExecute);
        }

        return new
        {
            formExecutionId = "9999234293492349",
            datatime = DateTime.Now.ToLongDateString(),
            result = "SUCCESS",
            form = form
        };
    }

    private string ExecuteExpression(string expression)
    {
        var dt = new DataTable();
        return string.Format("{0}", dt.Compute(expression, ""));
    }

    [HttpPost]
    [Route("script")]
    public Script AddScript([FromBody] Script script)
    {
        var json = JsonSerializer.Serialize(script);
        this._dataService.SaveScript(script.ScriptId, json);
        return script;
    }

    [HttpPost]
    [Route("script/{scriptId}/execution")]
    public object ExecuteScript([FromRoute] string scriptId, [FromBody] ExecuteScriptRequest request)
    {
        var script = this._dataService.GetScript(scriptId);

        return new
        {

            formExecutionId = "9999234293492349",
            datatime = DateTime.Now.ToLongDateString(),
            result = "SUCCESS",
            script = script
        };

    }
}