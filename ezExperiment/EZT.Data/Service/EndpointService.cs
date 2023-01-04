using System;
namespace EZT.Data.Service
{
    public class EndpointService : IEndpointService
    {
        private readonly string _baseUrl = "https://ezt-api.azurewebsites.net";
        public EndpointService()
        {

        }

        public string GetFormDefinitionUrl(string formId)
        {
            return string.Format("{0}/demo/form/{1}", this._baseUrl, formId);
        }
    }
}

