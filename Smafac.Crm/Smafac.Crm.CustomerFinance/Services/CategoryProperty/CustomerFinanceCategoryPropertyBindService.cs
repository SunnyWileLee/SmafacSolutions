using Smafac.Crm.CustomerFinance.Applications.CategoryProperty;
using Smafac.Crm.CustomerFinance.Domain;
using Smafac.Crm.CustomerFinance.Domain.CategoryProperty;
using Smafac.Crm.CustomerFinance.Repositories.Category;
using Smafac.Crm.CustomerFinance.Repositories.CategoryProperty;
using Smafac.Crm.CustomerFinance.Repositories.Property;
using Smafac.Framework.Core.Services.CategoryProperty;
using System.Collections.Generic;

namespace Smafac.Crm.CustomerFinance.Services.CategoryProperty
{
    class CustomerFinanceCategoryPropertyBindService : CategoryPropertyBindService<CustomerFinanceCategoryEntity, CustomerFinancePropertyEntity>,
                                        ICustomerFinanceCategoryPropertyBindService
    {
        public CustomerFinanceCategoryPropertyBindService(ICustomerFinanceCategoryPropertyBindRepository financeCategoryPropertyBindRepository,
                                                        ICustomerFinanceCategoryPropertySearchRepository financeCategoryPropertySearchRepository,
                                                        IEnumerable<ICustomerFinanceCategoryPropertyBindTrigger> financeCategoryPropertyBindTriggers,
                                                        ICustomerFinanceCategorySearchRepository financeCategorySearchRepository,
                                                        ICustomerFinancePropertySearchRepository financePropertySearchRepository
                                                )
        {
            base.EntityAssociationBindRepository = financeCategoryPropertyBindRepository;
            base.EntityAssociationSearchRepository = financeCategoryPropertySearchRepository;
            base.CategoryAssociationBindTriggers = financeCategoryPropertyBindTriggers;
            base.CategorySearchRepository = financeCategorySearchRepository;
            base.AssociationSearchRepository = financePropertySearchRepository;
        }

    }
}
