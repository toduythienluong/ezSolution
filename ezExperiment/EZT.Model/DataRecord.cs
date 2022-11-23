using System;
namespace EZT.Model
{
    public class DataRecord
    {
        public string DataRecordId { get; set; }
        public string RecordName { get; set; }
        public Section[] Sections { get; set; }
    }

    public class FilerRecord
    {
        public string DataRecordId { get; set; }
        public string RecordName { get; set; }
        public SectionNew[] Sections { get; set; }
    }
}

