using Microsoft.AspNetCore.Mvc;
using EZT.API.Message;
using System.Text.Json;
using System.Text.RegularExpressions;
using static System.Collections.Specialized.BitVector32;
using System.Data;
using EZT.Model;

namespace EZT.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TaxReturnController : ControllerBase
{

    private readonly ILogger<TaxReturnController> _logger;

    public TaxReturnController(ILogger<TaxReturnController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [Route("GetTaxReturns")]
    public IEnumerable<string> GetTaxReturns()
    {
        return new List<string>() {
            "federal",
            "ohio",
            "idiana"
        };
    }

    [HttpPost]
    [Route("Calculate")]
    public string CalculateDataRecord([FromBody] CalculateDataRecordRequest request)
    {
        //TODO this is just for demo

        var dataRecord = this.getDataRecordJsonString(request.DataRecord);
        var values = this.getDataFieldValue(dataRecord);

        foreach (var section in dataRecord.Sections)
        {
            foreach (var field in section.DataFields)
            {
                if (!CONSTAINT.FIELDTYPE.CALCULATED.Equals(field.FieldType))
                    continue;

                var regex = new Regex("(?<=\\{\\{)(\\w+\\.\\w+.*?)(?=\\}\\})");
                var replaced = field.CalculationExpression;
                var matches = regex.Matches(replaced);
                foreach (Match match in matches)
                {
                    var stringValue =
                    replaced = replaced.Replace("{{" + match + "}}", values[match.Value]);
                }

                field.ExpressionToExecute = replaced;

                var dt = new DataTable();
                field.FieldValue = this.ExecuteExpression(field.ExpressionToExecute);
            }
        }

        var jsonString = JsonSerializer.Serialize(dataRecord);
        return jsonString;
    }

    private DataRecord getDataRecordJsonString(string postString)
    {
        //TODO: to implement

        if (!"string".Equals(postString))
            return JsonSerializer.Deserialize<DataRecord>(postString);

        var mock = "{\"DataRecordId\":\"102340\",\"RecordName\":\"federal\",\"Sections\":[{\"SectionName\":\"personalinformation\",\"DataFields\":[{\"FieldName\":\"firstName\",\"FieldValue\":\"Adam\",\"FieldType\":\"input\",\"DataType\":\"string\"},{\"FieldName\":\"lastName\",\"FieldValue\":\"Smith\",\"FieldType\":\"input\",\"DataType\":\"string\"},{\"FieldName\":\"fullName\",\"FieldValue\":\"\",\"FieldType\":\"calculated\",\"DataType\":\"string\",\"CalculationExpression\":\"'{{federal.personalinformation.firstName}}' + ' ' + '{{federal.personalinformation.lastName}}'\",\"ExpressionToExecute\":\"\"}]},{\"SectionName\":\"income\",\"DataFields\":[{\"FieldName\":\"net\",\"FieldValue\":\"1100\",\"FieldType\":\"double\",\"DataType\":\"int\"},{\"FieldName\":\"tax\",\"FieldValue\":\"\",\"FieldType\":\"calculated\",\"DataType\":\"double\",\"CalculationExpression\":\"{{federal.income.net}} * 0.17\",\"ExpressionToExecute\":\"\"}]}]}";

        return JsonSerializer.Deserialize<DataRecord>(mock);
    }

    private string ExecuteExpression(string expression)
    {
        var dt = new DataTable();
        return string.Format("{0}", dt.Compute(expression, ""));
    }

    private Dictionary<string, string> getDataFieldValue(DataRecord dataRecord)
    {
        var dict = new Dictionary<string, string>();

        var recordName = dataRecord.RecordName;
        foreach (var section in dataRecord.Sections)
        {
            foreach (var field in section.DataFields)
            {
                dict.Add(string.Format("{0}.{1}.{2}", recordName, section.SectionName, field.FieldName), field.FieldValue);
            }
        }

        return dict;
    }
}