using Smafac.Framework.Core.Repositories.Pages;
using Smafac.Hrs.Employee.Domain;
using Smafac.Hrs.Employee.Models;

namespace Smafac.Hrs.Employee.Repositories.Pages
{
    interface IEmployeePageQueryRepository : IPageQueryRepository<EmployeeEntity, EmployeeModel>
    {

    }
}
