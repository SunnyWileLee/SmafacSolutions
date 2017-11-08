using Smafac.Framework.Core.Repositories.Category;
using Smafac.Hrs.Employee.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Employee.Repositories.Category
{
    class EmployeeCategoryAddRepository : CategoryAddRepository<EmployeeContext, EmployeeCategoryEntity>, IEmployeeCategoryAddRepository
    {
        public EmployeeCategoryAddRepository(IEmployeeContextProvider contextProvider)
        {
            base.ContextProvider  = contextProvider;
        }
    }
}
