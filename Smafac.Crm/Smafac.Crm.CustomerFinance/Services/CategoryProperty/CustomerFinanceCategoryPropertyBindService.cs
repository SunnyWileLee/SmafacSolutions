using Smafac.Crm.CustomerFinance.Applications.CategoryProperty;
using Smafac.Crm.CustomerFinance.Domain;
using Smafac.Crm.CustomerFinance.Repositories.CategoryProperty;
using Smafac.Framework.Core.Services.CategoryProperty;

namespace Smafac.Crm.CustomerFinance.Services.CategoryProperty
{
    class CustomerFinanceCategoryPropertyBindService : CategoryPropertyBindService<CustomerFinanceCategoryEntity, CustomerFinancePropertyEntity>,
                                        ICustomerFinanceCategoryPropertyBindService
    {
        public CustomerFinanceCategoryPropertyBindService(ICustomerFinanceCategoryPropertyBindRepository goodsCategoryPropertyBindRepository,
                                                ICustomerFinanceCategoryPropertySearchRepository goodsCategoryPropertySearchRepository
                                                )
        {
            base.EntityAssociationBindRepository = goodsCategoryPropertyBindRepository;
            base.EntityAssociationSearchRepository = goodsCategoryPropertySearchRepository;
        }

    }
}
