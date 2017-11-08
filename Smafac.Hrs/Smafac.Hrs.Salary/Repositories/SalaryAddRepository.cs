using Smafac.Framework.Core.Repositories;
using Smafac.Hrs.Salary.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Salary.Repositories
{
    class SalaryAddRepository : EntityAddRepository<SalaryContext, SalaryEntity>, ISalaryAddRepository
    {
        public SalaryAddRepository(ISalaryContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}
