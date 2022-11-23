using System;
using EZT.Model;

namespace EZT.Data.Service
{
    public class DataService : IDataService
    {
        private readonly Dictionary<string, string> _formDefs;
        private readonly Dictionary<string, string> _filerRecords;
        public DataService()
        {
            this._formDefs = new Dictionary<string, string>();
            this._filerRecords = new Dictionary<string, string>();
        }

        public void AddFormDefinition(string formName, string formDefinitionJson)
        {
            if (this._formDefs.ContainsKey(formName))
            {
                this._formDefs[formName] = formDefinitionJson;
                return;
            }

            this._formDefs.Add(formName, formDefinitionJson);
        }

        public string GetFormDefinition(string formName)
        {
            return this._formDefs[formName];
        }

        public void SaveFilerRecord(string filerRecordId, string filerRecordJson)
        {
            if (this._filerRecords.ContainsKey(filerRecordId))
            {
                this._filerRecords[filerRecordId] = filerRecordJson;
                return;
            }

            this._filerRecords.Add(filerRecordId, filerRecordJson);
        }

        public void SaveFields(string filerRecordId, DataFieldNew[] fields)
        {

        }

        public string GetFilerRecord(string filerRecordId)
        {
            return this._filerRecords[filerRecordId];
        }
    }
}

