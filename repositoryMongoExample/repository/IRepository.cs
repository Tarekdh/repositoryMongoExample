using repositoryMongoExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace repositoryMongoExample.repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        
        Task<List<T>> GetAll();
        Task<T> GetById(string id);
        Task<bool> Add(T entity);
        Task<T> Update(string id,T entity);
        Task<bool> Delete(string id);
    }
}
