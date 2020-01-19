using MongoDB.Bson.Serialization.Attributes;
using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace repositoryMongoExample.Models
{
    public class User : BaseEntity
    {
        [JsonProperty("firstName")]
        [BsonElement("firstName")]
        public string FirstName { get; set; }


        [JsonProperty("lastName")]
        [BsonElement("lastName")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        [BsonElement("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        [BsonElement("password")]
        public string Password { get; set; }

        [JsonProperty("token")]
        [BsonElement("token")]
        public string Token { get; set; }

        public override String ToString()
        {
            var serializer = new JavaScriptSerializer();
            return serializer.Serialize(this);
        }
    }
}
