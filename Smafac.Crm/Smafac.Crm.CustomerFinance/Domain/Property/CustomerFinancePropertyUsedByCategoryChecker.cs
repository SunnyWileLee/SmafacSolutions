using Smafac.Crm.CustomerFinance.Repositories.CategoryProperty;
using Smafac.Framework.Core.Domain.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.CustomerFinance.Domain.Property
{
    class CustomerFinancePropertyUsedByCategoryChecker : PropertyUsedByCategoryChecker<CustomerFinanceCategoryEntity, CustomerFinancePropertyEntity>,
                                                ICustomerFinancePropertyUsedChecker
    {
        public CustomerFinancePropertyUsedByCategoryChecker(ICustomerFinanceCategoryPropertySearchRepository customerFinanceCategoryPropertySearchRepository)
        {
            base.CategoryPropertySearchRepository = customerFinanceCategoryPropertySearchRepository;
        }
    }
}
