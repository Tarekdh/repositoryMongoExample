using repositoryMongoExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace repositoryMongoExample.repository
{
    public interface IUserRepository
    {

        Task<User> Authentificate(string login, string password);
    
    }
}
