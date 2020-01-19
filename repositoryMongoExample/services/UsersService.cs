using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using repositoryMongoExample.Data;
using repositoryMongoExample.JWT;
using repositoryMongoExample.Models;
using repositoryMongoExample.repository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace repositoryMongoExample.services
{

    //public class NoteService : Service<NoteRepository, Note>, IService<IRepository<Note>, Note>
    public class UsersService : Service<IRepository<User>, User>, IUserService

    {
        public UserRepository  _userRepository;
        public string _secret;

        public UsersService(IRepository<User> repository,
            IOptions<AppSettings> settings)
            : base(repository)
        {
            _userRepository = repository as UserRepository;
            _secret = settings.Value.Secret;
        }

        public async Task<User> Authentificate(string login, string password)
        {
            var user = await _userRepository.Authentificate(login, password);
            if (user != null)
            {
                user.Token = TokenManager.GenerateToken(user.Id.ToString());
            }
            //{
            //    var tokenHandler = new JwtSecurityTokenHandler();
            //    var key = Encoding.ASCII.GetBytes(_secret);
            //    var tokenDescriptor = new SecurityTokenDescriptor
            //    {
            //        Subject = new ClaimsIdentity(new Claim[]
            //        {
            //        new Claim(ClaimTypes.Name, user.ToString())
            //        }),
            //        Expires = DateTime.UtcNow.AddHours(1),
            //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            //    };
            //    var token = tokenHandler.CreateToken(tokenDescriptor);
            //    user.Token = tokenHandler.WriteToken(token);
            //}
            return user;
        }
    }
}
