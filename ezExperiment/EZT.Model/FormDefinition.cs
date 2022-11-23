using System;
namespace EZT.Model
{
    public class FormDefinition
    {
        public string FormName { get; set; }
        public FieldDef[] FieldDefs { get; set; }
    }

    public class FieldDef
    {
        public string DisplayText { get; set; }
        public string Datamapping { get; set; }
        public string Type { get; set; }
        public string? FieldValue { get; set; }
    }
}

