using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace repositoryMongoExample.ViewModel
{
    public class Register
    {
        public virtual string Email { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }

    }
}
