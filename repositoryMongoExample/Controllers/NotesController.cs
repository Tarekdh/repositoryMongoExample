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
    public class NotesController : ControllerBase
    {
        private IService<NoteRepository,Note> _noteService;

        public NotesController(IService<NoteRepository, Note> noteService)
        {
            _noteService = noteService;
        }

        // GET api/values
        [HttpGet]
        public async Task<List<Note>> GetAll()
        {
            return await _noteService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Note> GetById(string id)
        {
            return await _noteService.GetById(id);
        }

        [HttpPut("{id}")]
        public async Task<Note> UpdateNote([FromBody] Note note, string id)
        {
            return await _noteService.Update(id,note);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteById(string id)
        {
            return await _noteService.Delete(id);
        }


        // GET api/values
        [HttpPost]
        public async Task<Note> AddNote([FromBody] Note note)
        {
           return await _noteService.Add(note);
        }

    }
}