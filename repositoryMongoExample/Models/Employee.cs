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
       
        string FirstName { get; set; }

        string LastName { get; set; }

        string Department { get; set; }

        float Salary { get; set; }

    }
}
