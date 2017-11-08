using Smafac.Framework.Core.Repositories.Property;
using Smafac.Hrs.Employee.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Employee.Repositories.Property
{
    class EmployeePropertySearchRepository : PropertySearchRepository<EmployeeContext, EmployeePropertyEntity>, IEmployeePropertySearchRepository
    {
        public EmployeePropertySearchRepository(IEmployeeContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}
