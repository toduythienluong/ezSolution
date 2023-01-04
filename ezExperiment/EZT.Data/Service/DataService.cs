using System;
using EZT.Model;

namespace EZT.Data.Service
{
    public class DataService : IDataService
    {
        private readonly Dictionary<string, string> _formDefs;
        private readonly Dictionary<string, string> _filerRecords;
        private readonly Dictionary<string, string> _scripts;
        public DataService()
        {
            this._formDefs = new Dictionary<string, string>();
            this._filerRecords = new Dictionary<string, string>();
            this._scripts = new Dictionary<string, string>();
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

        public int AddForm(string formId, string formDefinitionJson)
        {
            if (this._formDefs.ContainsKey(formId))
            {
                this._formDefs[formId] = formDefinitionJson;
                return 1;
            }

            this._formDefs.Add(formId, formDefinitionJson);
            return 0;
        }

        public int UpdateForm(string formId, string formDefinitionJson)
        {
            if (this._formDefs.ContainsKey(formId))
            {
                this._formDefs[formId] = formDefinitionJson;
                return 1;
            }

            this._formDefs[formId] = formDefinitionJson;
            return 0;
        }

        public string GetFormDefinition(string formName)
        {
            return this._formDefs[formName];
        }

        public string GetFormById(string formId)
        {
            return this._formDefs[formId];
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

        public int SaveScript(string scriptId, string scriptJson)
        {
            if (this._scripts.ContainsKey(scriptId))
            {
                this._scripts[scriptId] = scriptJson;
                return 1;
            }

            this._scripts.Add(scriptId, scriptJson);
            return 0;
        }

        public string GetScript(string scriptId)
        {
            return this._scripts[scriptId];
        }

    }
}

