using repositoryMongoExample.Models;
using repositoryMongoExample.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace repositoryMongoExample.services
{

    public class EmployeeService : BaseService<Employee>

    {

        public EmployeeService(IRepository<Employee> repository)
            : base(repository)
        {
        }

    }
}
