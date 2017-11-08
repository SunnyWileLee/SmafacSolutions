using Smafac.Framework.Core.Repositories.Property;
using Smafac.Hrs.Salary.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Salary.Repositories.Property
{
    class SalaryPropertyAddRepository : PropertyAddRepository<SalaryContext, SalaryPropertyEntity>, ISalaryPropertyAddRepository
    {
        public SalaryPropertyAddRepository(ISalaryContextProvider contextProvider)
        {
            base.ContextProvider  = contextProvider;
        }
    }
}
