using Smafac.Framework.Core.Repositories.CategoryProperty;
using Smafac.Hrs.Salary.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Salary.Repositories.CategoryProperty
{
    class SalaryCategoryPropertySearchRepository : CategoryPropertySearchRepository<SalaryContext, SalaryCategoryEntity, SalaryPropertyEntity, SalaryCategoryPropertyEntity>,
                                                  ISalaryCategoryPropertySearchRepository
    {
        public SalaryCategoryPropertySearchRepository(ISalaryContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}
