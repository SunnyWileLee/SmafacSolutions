using Smafac.Framework.Core.Repositories.CategoryProperty;
using Smafac.Hrs.Employee.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Employee.Repositories.CategoryProperty
{
    interface IEmployeeCategoryPropertyBindRepository : ICategoryPropertyBindRepository<EmployeeCategoryEntity, EmployeePropertyEntity>
    {
    }
}
