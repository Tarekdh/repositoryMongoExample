using Microsoft.Extensions.Options;
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
    public abstract class BaseRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : BaseEntity
        where TContext : MyDbContext
    {
        public MyDbContext _context = null;
        public IMongoCollection<TEntity> _collection = null;
        public BaseRepository(MyDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(TEntity entity)
        {
            try
            {
               await _collection.InsertOneAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> Delete(string id)
        {
            try
            {
                DeleteResult actionResult
                = await _collection.DeleteOneAsync(
                    Builders<TEntity>.Filter.Eq("Id", new ObjectId(id)));

                return actionResult.IsAcknowledged
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<TEntity> GetById(string id)
        {
            try
            {
                ObjectId objId = new ObjectId(id);
                return await _collection
                                .Find(e => e.Id == objId)
                                .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<List<TEntity>> GetAll()
        {
            try
            {
                return await _collection.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<TEntity> Update(string id,TEntity entity)
        {
            entity.Id = new ObjectId(id);
            var filter = Builders<TEntity>.Filter.Eq(s => s.Id, new ObjectId(id));
            try
            {

                ReplaceOneResult replaceResult
                    = await _collection.ReplaceOneAsync(filter,entity);


                if (replaceResult.IsAcknowledged)
                {
                    return await _collection
                                .Find(e => e.Id == new ObjectId(id))
                                .FirstOrDefaultAsync(); ;
                }
                return entity;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }
    }
}
