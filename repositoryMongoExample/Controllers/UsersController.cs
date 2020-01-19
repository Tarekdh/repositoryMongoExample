using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using repositoryMongoExample.Models;
using repositoryMongoExample.repository;
using repositoryMongoExample.services;

namespace repositoryMongoExample.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController<
        IService<IRepository<User>, User>,
        IRepository<User>,
        User>
    {
        private UsersService _usersService;

        public UsersController(IService<IRepository<User>,User> service)
            : base(service)
        {
            _usersService = service as UsersService;
        }

        [HttpPost("login")]
        public async Task<User> Authentificate([FromBody] Authentication auth)
        {
            User user = await _usersService.Authentificate(auth.Login,auth.Password);
            return user != null ? user : null;
        }
    }
}