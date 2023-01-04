using System;
using EZT.Model;

namespace EZT.API.Message
{
    public class AddOrUpdateFilterRecordRequest : RequestBase
    {
        public string CustomerId { get; set; }
        public FilerRecord DataRecordSchema { get; set; }
    }
}

