using Smafac.Crm.CustomerFinance.Repositories.CategoryProperty;
using Smafac.Framework.Core.Domain.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.CustomerFinance.Domain.Property
{
    class CustomerFinancePropertyDeleteCategoryTrigger : PropertyDeleteCategoryTrigger<CustomerFinanceCategoryEntity, CustomerFinancePropertyEntity, CustomerFinanceCategoryPropertyEntity>,
        ICustomerFinancePropertyDeleteTrigger
    {
        public CustomerFinancePropertyDeleteCategoryTrigger(ICustomerFinanceCategoryPropertyBindRepository customerFinanceCategoryPropertyBindRepository)
        {
            base.CategoryPropertyBindRepository = customerFinanceCategoryPropertyBindRepository;
        }
    }
}
