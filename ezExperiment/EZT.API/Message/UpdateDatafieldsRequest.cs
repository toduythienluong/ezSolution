using System;
using EZT.Model;

namespace EZT.API.Message
{
    public class UpdateDatafieldsRequest : RequestBase
    {
        public string FilerRecordId { get; set; }
        public DataFieldNew[] DataFieldsToUpdate { get; set; }

    }
}

