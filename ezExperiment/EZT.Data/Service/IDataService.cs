using System;
using EZT.Model;

namespace EZT.Data.Service
{
    public interface IDataService
    {
        public void AddFormDefinition(string formName, string formDefinitionJson);
        public string GetFormDefinition(string formName);
        void SaveFilerRecord(string filerRecordId, string filerRecordJson);
        string GetFilerRecord(string filerRecordId);
    }
}

