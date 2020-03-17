using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace repositoryMongoExample.JWT
{
    public class Token
    {

        public string key { get; set; }
        public DateTime expiration { get; set; }
    }
}
