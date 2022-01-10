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
    public class NotesController : BaseController<Note>
    {
        private IService<Note> _noteService;

        public NotesController(IService<Note> service)
            : base(service)
        {
            _noteService = service;
        }
    }
}