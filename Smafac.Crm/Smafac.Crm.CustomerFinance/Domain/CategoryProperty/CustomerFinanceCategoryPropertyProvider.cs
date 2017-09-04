using Smafac.Crm.CustomerFinance.Models;
using Smafac.Crm.CustomerFinance.Repositories.Category;
using Smafac.Crm.CustomerFinance.Repositories.CategoryProperty;
using Smafac.Framework.Core.Domain.EntityAssociationProviders;

namespace Smafac.Crm.CustomerFinance.Domain.CategoryProperty
{
    class CustomerFinanceCategoryPropertyProvider: CategoryPropertyProvider<CustomerFinanceCategoryEntity, CustomerFinancePropertyEntity, CustomerFinancePropertyModel> ,
                                        ICustomerFinanceCategoryPropertyProvider
    {
        public CustomerFinanceCategoryPropertyProvider(ICustomerFinanceCategorySearchRepository customerFinanceCategorySearchRepository,
                                               ICustomerFinanceCategoryPropertySearchRepository customerFinanceCategoryPropertySearchRepository)
        {
            base.CategorySearchRepository = customerFinanceCategorySearchRepository;
            base.CategoryAssociationSearchRepository = customerFinanceCategoryPropertySearchRepository;
        }
    }
}
