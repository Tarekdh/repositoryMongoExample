using repositoryMongoExample.Models;
using repositoryMongoExample.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace repositoryMongoExample.services
{
    public interface IService<TRepository,TEntity>
        where TRepository : IRepository<TEntity>
        where TEntity : BaseEntity

    {
        Task<List<TEntity>> GetAll();
        Task<TEntity> GetById(string id);
        Task<TEntity> Update(string id, TEntity entity);
        Task<TEntity> Add(TEntity entity);
        Task<bool> Delete(string id);
    }
}
