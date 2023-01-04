using System;
using EZT.Model;

namespace EZT.API.Message
{
    public class FormExecutionRequest : RequestBase
    {
        public string FilerId { get; set; }
        public Dictionary<string, string> Parameters { get; set; }
        public string FireEvents { get; set; }

    }
}

