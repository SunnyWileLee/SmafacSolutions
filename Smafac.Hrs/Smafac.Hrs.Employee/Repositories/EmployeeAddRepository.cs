using Smafac.Framework.Core.Repositories;
using Smafac.Hrs.Employee.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Employee.Repositories
{
    class EmployeeAddRepository : EntityAddRepository<EmployeeContext, EmployeeEntity>, IEmployeeAddRepository
    {
        public EmployeeAddRepository(IEmployeeContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}
