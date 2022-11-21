using System;
namespace EZT.API.Message
{
    public class CalculateDataRecordRequest : RequestBase
    {
        public string DataRecord { get; set; }

        public CalculateDataRecordRequest()
        {
            this.DataRecord = string.Empty;
        }
    }
}

