using Smafac.Framework.Core.Repositories.CategoryProperty;
using Smafac.Hrs.Salary.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Salary.Repositories.CategoryProperty
{
    class SalaryCategoryPropertyBindRepository : CategoryPropertyBindRepository<SalaryContext, SalaryCategoryEntity, SalaryPropertyEntity, SalaryCategoryPropertyEntity>,
                                                ISalaryCategoryPropertyBindRepository
    {
        public SalaryCategoryPropertyBindRepository(ISalaryContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}
