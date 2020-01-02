using repositoryMongoExample.Models;
using repositoryMongoExample.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace repositoryMongoExample.services
{

    //public class NoteService : Service<NoteRepository, Note>, IService<IRepository<Note>, Note>
    public class EmployeeService : Service<IRepository<Employee >, Employee>

    {

        public EmployeeService(IRepository<Employee> repository)
            : base(repository)
        {
        }

    }
}
