using System;
using EZT.Model;

namespace EZT.API.Message
{
    public class AddOrUpdateFilerRecordResponse : ResponseBase
    {
        public string CustomerId { get; set; }
        public string FilerRecordId { get; set; }
        public string DataRecordJson { get; set; }

    }
}

