using Smafac.Hrs.Employee.Domain;
using Smafac.Hrs.Employee.Models;
using System.Linq;

namespace Smafac.Hrs.Employee.Repositories.Joiners
{
    interface IEmployeeJoiner
    {
        IQueryable<EmployeeModel> Join(IQueryable<EmployeeEntity> goodses, IQueryable<EmployeeCategoryEntity> categories);
    }
}
