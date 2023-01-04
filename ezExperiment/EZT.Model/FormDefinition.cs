using System;
namespace EZT.Model
{
    public class FormDefinition
    {
        public string FormName { get; set; }
        public string FormId { get; set; }
        public DemoFieldDef[] FieldDefs { get; set; }
    }

    public class DemoForm
    {
        public string FormId { get; set; }
        public string FormName { get; set; }
        public DemoFieldDef[] FieldDefs { get; set; }
    }

    public class FieldDef
    {
        public string DisplayText { get; set; }
        public string Datamapping { get; set; }
        public string Type { get; set; }
        public string? FieldValue { get; set; }
    }

    public class DemoFieldDef
    {
        public string FieldId { get; set; }
        public string FieldName { get; set; }
        public string DisplayText { get; set; }
        public string Datamapping { get; set; }
        public string Type { get; set; }
        public string? FieldValue { get; set; }
        public string InputType { get; set; }
        public string? CalculationExpression { get; set; }
        public string? Event { get; set; }
    }
}

