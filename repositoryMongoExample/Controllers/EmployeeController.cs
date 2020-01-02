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
    public class EmployeeController : BaseController<
        IService<IRepository<Employee>, Employee>,
        IRepository<Employee>,
        Employee>
    {
        private IService<IRepository<Employee>, Employee> _noteService;

        public EmployeeController(IService<IRepository<Employee>, Employee> service)
            : base(service)
        {
            _noteService = service;
        }
    }
}