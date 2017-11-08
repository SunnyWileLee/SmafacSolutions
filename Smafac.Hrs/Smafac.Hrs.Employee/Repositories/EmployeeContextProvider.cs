using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Employee.Repositories
{
    class EmployeeContextProvider : IEmployeeContextProvider
    {
        public EmployeeContext Provide()
        {
            return new EmployeeContext();
        }

        public EmployeeContext ProvideSlave()
        {
            return new EmployeeContext();
        }
    }
}
