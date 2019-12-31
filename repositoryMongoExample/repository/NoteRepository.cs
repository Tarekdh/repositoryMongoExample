using repositoryMongoExample.Data;
using repositoryMongoExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace repositoryMongoExample.repository
{
    public class NoteRepository : BaseRepository<Note,MyDbContext> 
    {
        public NoteRepository(MyDbContext context) : base(context) => _collection = _context.Notes;

    }
}
