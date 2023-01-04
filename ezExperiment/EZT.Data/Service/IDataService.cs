using System;
using EZT.Model;

namespace EZT.Data.Service
{
    public interface IDataService
    {
        public void AddFormDefinition(string formName, string formDefinitionJson);
        public int AddForm(string formId, string formDefinitionJson);
        public int UpdateForm(string formId, string formDefinitionJson);
        public string GetFormById(string formId);
        public string GetFormDefinition(string formName);
        void SaveFilerRecord(string filerRecordId, string filerRecordJson);
        string GetFilerRecord(string filerRecordId);
        int SaveScript(string scriptId, string scriptJson);
        public string GetScript(string scriptId);
    }
}

