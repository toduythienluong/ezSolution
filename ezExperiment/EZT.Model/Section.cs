using System;
namespace EZT.Model
{
    public class Section
    {
        public string SectionName { get; set; }
        public DataField[] DataFields { get; set; }
    }

    public class SectionNew
    {
        public string SectionName { get; set; }
        public DataFieldNew[] DataFields { get; set; }
    }

    public class DemoSection
    {
        public string SectionId { get; set; }
        public string SectionName { get; set; }
        public List<DemoDataField> DataFields { get; set; }
    }
}

