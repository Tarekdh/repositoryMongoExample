using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace repositoryMongoExample.Models
{
    public class Employee : BaseEntity
    {
        [JsonProperty("firstname")]
        [BsonElement("firstname")]
        string FirstName { get; set; }


        [JsonProperty("lastname")]
        [BsonElement("lastname")]
        string LastName { get; set; }

        [JsonProperty("department")]
        [BsonElement("department")]
        string Department { get; set; }

        [JsonProperty("salary")]
        [BsonElement("salary")]
        float Salary { get; set; }

    }
}
