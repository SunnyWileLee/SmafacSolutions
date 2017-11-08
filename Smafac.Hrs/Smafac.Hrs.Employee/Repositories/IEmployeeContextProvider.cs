using Smafac.Framework.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Employee.Repositories
{
    interface IEmployeeContextProvider : IDbContextProvider<EmployeeContext>
    {

    }
}
