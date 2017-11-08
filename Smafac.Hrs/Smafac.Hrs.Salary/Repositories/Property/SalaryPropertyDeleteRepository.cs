using Smafac.Framework.Core.Repositories.Property;
using Smafac.Hrs.Salary.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Salary.Repositories.Property
{
    class SalaryPropertyDeleteRepository : PropertyDeleteRepository<SalaryContext, SalaryPropertyEntity>, ISalaryPropertyDeleteRepository
    {
        public SalaryPropertyDeleteRepository(ISalaryContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}
