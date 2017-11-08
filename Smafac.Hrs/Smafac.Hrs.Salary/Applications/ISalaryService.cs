using Smafac.Hrs.Salary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Salary.Applications
{
    public interface ISalaryService
    {
        ISalaryUpdateService UpdateService { get; set; }
        bool AddSalary(SalaryModel model);
        SalaryModel CreateEmptySalary();
    }
}
