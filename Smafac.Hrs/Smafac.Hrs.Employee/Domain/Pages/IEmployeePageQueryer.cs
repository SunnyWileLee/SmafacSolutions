using Smafac.Framework.Core.Domain.Pages;
using Smafac.Hrs.Employee.Models;

namespace Smafac.Hrs.Employee.Domain.Pages
{
    interface IEmployeePageQueryer : IPageQueryer<EmployeeModel, EmployeePageQueryModel>
    {
    }
}
