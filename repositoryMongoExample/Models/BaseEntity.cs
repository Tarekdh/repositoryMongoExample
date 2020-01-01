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
        public string InternalId { get; set; }

        [BsonElement("CreatedBy")]
        [JsonProperty("CreatedBy")]
        public string CreatedBy { get; set; }

        [BsonElement("ModifiedBy")]
        [JsonProperty("ModifiedBy")]
        public string ModifiedBy { get; set; }

        //[BsonDateTimeOptions(DateOnly = true)]
        public DateTime? CreatedAt { get; set; } = null;

        //[BsonDateTimeOptions(DateOnly = true)]
        public DateTime? ModifiedAt { get; set; } = null;


        public BaseEntity()
        {
            Id = ObjectId.GenerateNewId();
        }


    }
}
