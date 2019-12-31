using repositoryMongoExample.Models;
using repositoryMongoExample.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace repositoryMongoExample.services
{
    public class NoteService : Service<NoteRepository,Note>
    {

        public NoteService(IRepository<Note> repository):base(repository)
        {
        }

    }
}
