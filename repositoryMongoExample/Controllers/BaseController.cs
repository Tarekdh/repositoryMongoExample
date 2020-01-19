using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using repositoryMongoExample.JWT;
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

        protected BaseController(TService service)
        {
            _service = service;
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public virtual async Task<List<TEntity>> GetAll()
        {
            return await _service.GetAll();
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{id}")]
        public virtual async Task<TEntity> GetById(string id)
        {
            return await _service.GetById(id);
        }

        [HttpPut("{id}")]
        public virtual async Task<TEntity> UpdateNote([FromBody] TEntity note, string id)
        {
            return await _service.Update(id, note);
        }

        [HttpDelete("{id}")]
        public virtual async Task<bool> DeleteById(string id)
        {
            return await _service.Delete(id);
        }


        [HttpPost]
        public async Task<TEntity> Add([FromBody] TEntity entity)
        {
            return await _service.Add(entity);
        }
    }
}