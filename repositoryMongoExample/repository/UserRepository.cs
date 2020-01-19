using MongoDB.Bson;
using MongoDB.Driver;
using repositoryMongoExample.Data;
using repositoryMongoExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace repositoryMongoExample.repository
{
    public class UserRepository : BaseRepository<User,MyDbContext> , IUserRepository
    {
        public UserRepository(MyDbContext context) : base(context) => _collection = _context.Users;

        public async Task<User> Authentificate(string login, string password)
        {
            try
            {
                var builder = Builders<BsonDocument>.Filter;
                var filter = builder.Eq("Email", login) & builder.Eq("Password", password);

                return await _collection.Find(x=>x.Email == login &
                                x.Password == password)
                                .FirstOrDefaultAsync(); ;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }
    }
}
