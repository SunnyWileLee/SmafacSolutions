using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Salary.Repositories
{
    class SalaryContextProvider : ISalaryContextProvider
    {
        public SalaryContext Provide()
        {
            return new SalaryContext();
        }

        public SalaryContext ProvideSlave()
        {
            return new SalaryContext();
        }
    }
}
