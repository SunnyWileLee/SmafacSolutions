using Smafac.Framework.Core.Models;
using Smafac.Hrs.Employee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Employee.Applications
{
    public interface IEmployeeSearchService
    {
        EmployeeModel GetEmployee(Guid employeeId);
        EmployeeDetailModel GetEmployeeDetail(Guid employeeId);
        PageModel<EmployeeModel> GetEmployeePage(EmployeePageQueryModel query);
        List<EmployeeModel> GetEmployee(EmployeePageQueryModel query);
        List<EmployeeModel> GetEmployee(IEnumerable<Guid> employeeIds);
    }
}
