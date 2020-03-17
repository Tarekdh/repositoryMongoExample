using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace repositoryMongoExample.Data
{
    public class JwtSettings
    {
        public string SigningKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string LifeTime { get; set; }
    }
}
