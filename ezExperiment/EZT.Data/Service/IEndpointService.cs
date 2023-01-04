using System;
using EZT.Model;

namespace EZT.Data.Service
{
    public interface IEndpointService
    {
        public string GetFormDefinitionUrl(string formId);
    }
}

