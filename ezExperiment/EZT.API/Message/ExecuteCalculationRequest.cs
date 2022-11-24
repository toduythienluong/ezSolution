using System;
using EZT.Model;

namespace EZT.API.Message
{
    public class ExecuteCalculationRequest
    {
        public string FilerRecordId { get; set; }
        public Calculation Calculation { get; set; }
    }

    public class ExecuteCalculationWithParameterRequest
    {
        public Dictionary<string, string> Parameters { get; set; }
        public Calculation Calculation { get; set; }
    }

}

