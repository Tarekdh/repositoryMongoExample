using repositoryMongoExample.Models;
using repositoryMongoExample.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace repositoryMongoExample.services
{

    //public class NoteService : Service<NoteRepository, Note>, IService<IRepository<Note>, Note>
    public class NoteService : Service<IRepository<Note>, Note>

    {

        public NoteService(IRepository<Note> repository)
            : base(repository)
        {
        }

    }
}
