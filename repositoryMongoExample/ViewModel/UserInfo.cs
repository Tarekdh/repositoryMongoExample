using repositoryMongoExample.JWT;
using repositoryMongoExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace repositoryMongoExample.ViewModel
{
    public class UserInfo
    {
        public Token token { get; set; }
        public ApplicationUser user { get; set; }


    }
}
