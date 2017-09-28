using Smafac.Crm.CustomerFinance.Domain;
using Smafac.Crm.CustomerFinance.Repositories.Category;
using Smafac.Framework.Core.Services.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.CustomerFinance.Services.Category
{
    class CustomerFinanceCategoryInitialization : CategoryInitialization<CustomerFinanceCategoryEntity>
    {
        public CustomerFinanceCategoryInitialization(ICustomerFinanceCategoryAddRepository financeCategoryAddRepository,
                                        ICustomerFinanceCategorySearchRepository financeCategorySearchRepository
                                        )
        {
            base.CategoryAddRepository = financeCategoryAddRepository;
            base.CategorySearchRepository = financeCategorySearchRepository;
        }
    }
}
