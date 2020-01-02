using repositoryMongoExample.Data;
using repositoryMongoExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace repositoryMongoExample.repository
{
    public class EmployeeRepository : BaseRepository<Employee,MyDbContext> 
    {
        public EmployeeRepository(MyDbContext context) : base(context) => _collection = _context.employee;

    }
}
