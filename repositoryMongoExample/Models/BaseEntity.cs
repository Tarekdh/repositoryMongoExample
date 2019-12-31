using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace repositoryMongoExample.Models
{
    public class BaseEntity
    {
        

        [BsonId]
        public ObjectId Id { get; set; }
        string InternalId { get; set; }

        [BsonElement("CreatedBy")]
        [JsonProperty("CreatedBy")]
        string CreatedBy { get; set; }

        [BsonElement("ModifiedBy")]
        [JsonProperty("ModifiedBy")]
        string ModifiedBy { get; set; }

        [BsonDateTimeOptions(DateOnly = true)]
        DateTime CreatedAt { get; set; } = new DateTime();

        [BsonDateTimeOptions(DateOnly = true)]
        DateTime ModifiedAt { get; set; } = new DateTime();

    }
}
