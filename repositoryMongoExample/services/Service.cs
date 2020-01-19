using repositoryMongoExample.Models;
using repositoryMongoExample.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace repositoryMongoExample.services
{
    public abstract class Service<TRepository, TEntity> : IService<TRepository, TEntity>
        where TRepository : IRepository<TEntity>
        where TEntity : BaseEntity
    {

        public IRepository<TEntity> _repository;
        public Service(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            return await _repository.Add(entity);
        }

        public async Task<bool> Delete(string id)
        {
            return await _repository.Delete(id);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<TEntity> GetById(string id)
        {
            return await _repository.GetById(id);
        }

        public async Task<TEntity> Update(string id, TEntity entity)
        {
            return await _repository.Update(id, entity);

        }



    }
}
