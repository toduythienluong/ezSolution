using System;
using EZT.Model;

namespace EZT.API.Message
{
    public class AddFormDefinitionRequest : RequestBase
    {
        public string CustomerId { get; set; }
        public FilerRecord DataRecordSchema { get; set; }

    }
}

