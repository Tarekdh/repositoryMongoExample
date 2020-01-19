using repositoryMongoExample.Models;
using repositoryMongoExample.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace repositoryMongoExample.services
{
    public interface IUserService

    {
        Task<User> Authentificate(string login, string password);
    }
}
