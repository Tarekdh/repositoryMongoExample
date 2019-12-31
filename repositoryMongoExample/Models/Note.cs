using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace repositoryMongoExample.Models
{
    public class Note : BaseEntity
    {
        [JsonProperty("name")]
        [BsonElement("name")]
        string Name { get; set; }


        [JsonProperty("body")]
        [BsonElement("body")]
        string Body { get; set; }
    }
}
