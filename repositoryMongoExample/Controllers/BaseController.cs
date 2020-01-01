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
    public abstract class BaseController<TService,TRepository,TEntity> : ControllerBase
        where TService : class, IService<TRepository,TEntity>
        where TRepository : IRepository<TEntity>
        where TEntity : BaseEntity
    {
        private readonly TService _service;

        public BaseController(TService service)
        {
            _service = service;
        }

       

        // GET api/values
        [HttpGet]
        public async Task<List<TEntity>> GetAll()
        {
            return await _service.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<TEntity> GetById(string id)
        {
            return await _service.GetById(id);
        }

        [HttpPut("{id}")]
        public async Task<TEntity> UpdateNote([FromBody] TEntity note, string id)
        {
            return await _service.Update(id, note);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteById(string id)
        {
            return await _service.Delete(id);
        }


        // GET api/values
        [HttpPost]
        public async Task<TEntity> AddNote([FromBody] TEntity note)
        {
            return await _service.Add(note);
        }
    }
}