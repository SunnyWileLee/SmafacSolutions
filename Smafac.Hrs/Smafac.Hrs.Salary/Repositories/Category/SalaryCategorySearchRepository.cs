using Smafac.Framework.Core.Repositories.Category;
using Smafac.Hrs.Salary.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Salary.Repositories.Category
{
    class SalaryCategorySearchRepository : CategorySearchRepository<SalaryContext, SalaryCategoryEntity>, ISalaryCategorySearchRepository
    {
        public SalaryCategorySearchRepository(ISalaryContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}
