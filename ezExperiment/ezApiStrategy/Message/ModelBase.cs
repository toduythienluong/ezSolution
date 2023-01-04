using System;
using System.Text.Json.Serialization;

namespace ezApiStrategy.Message
{
    public class ModelBase
    {
        [JsonIgnore]
        public string UserCreated { get; set; }
        [JsonIgnore]
        public DateTime DateCreated { get; set; }
        [JsonIgnore]
        public string LastUpdatedBy { get; set; }
        [JsonIgnore]
        public DateTime LastUpdatedDate { get; set; }
    }
}

