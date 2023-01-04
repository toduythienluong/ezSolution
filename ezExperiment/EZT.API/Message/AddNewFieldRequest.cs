using System;
using EZT.Model;

namespace EZT.API.Message
{
    public class AddNewFieldRequest : RequestBase
    {
        public string SectionId { get; set; }
        public DemoDataField DataField { get; set; }
    }
}

