using Smafac.Hrs.Employee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Employee.Applications
{
    public interface IEmployeeService
    {
        IEmployeeUpdateService UpdateService { get; set; }
        bool AddEmployee(EmployeeModel model);
        EmployeeModel CreateEmptyEmployee();
    }
}
