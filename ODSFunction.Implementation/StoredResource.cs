using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODSFunction.Implementation
{
    public abstract class StoredResource
    {
        [JsonProperty("id")]
        public virtual string Id { get; set; }

        [JsonProperty("_etag")]
        public string ETag { get; set; }

        [JsonProperty("Removed")]
        public bool Removed { get; set; }

        [JsonProperty("CreatedBy")]
        public string CreatedBy { get; set; }

        [JsonProperty("CreatedDateTime")]
        public DateTime CreatedDateTime { get; set; }

        [JsonProperty("ModifiedBy")]
        public string ModifiedBy { get; set; }

        [JsonProperty("ModifiedDateTime")]
        public DateTime ModifiedDateTime { get; set; }

        [JsonProperty("SchemaVersion")]
        public abstract string SchemaVersion { get; protected set; }

        public string PartitionKey
        {
            get { return Id; }
        }
    }
}
