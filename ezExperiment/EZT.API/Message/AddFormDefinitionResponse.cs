using System;
using EZT.Model;

namespace EZT.API.Message
{
    public class AddFormDefinitionResponse : ResponseBase
    {
        public string FormName { get; set; }
        public string FormDefJson { get; set; }
    }
}

