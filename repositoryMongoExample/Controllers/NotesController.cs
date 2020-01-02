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
    public class NotesController : BaseController<
        IService<IRepository<Note>, Note>,
        IRepository<Note>,
        Note>
    {
        private IService<IRepository<Note>, Note> _noteService;

        public NotesController(IService<IRepository<Note>, Note> service)
            : base(service)
        {
            _noteService = service;
        }
    }
}