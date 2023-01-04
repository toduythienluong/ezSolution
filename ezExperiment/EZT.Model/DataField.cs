using System;
namespace EZT.Model
{
    public class DataField
    {
        public string FieldName { get; set; }
        public string FieldBinding { get; set; }
        public string FieldValue { get; set; }
        public string FieldType { get; set; }
        public string DataType { get; set; }
        public string CalculationExpression { get; set; }
        public string ExpressionToExecute { get; set; }
    }

    public class DataFieldNew
    {
        public string FieldName { get; set; }
        public string FieldBinding { get; set; }
        public string FieldValue { get; set; }
    }

    public class DemoDataField
    {
        public string FieldId { get; set; }
        public string FieldName { get; set; }
        public string FieldValue { get; set; }
        public string FieldType { get; set; }
    }
}

