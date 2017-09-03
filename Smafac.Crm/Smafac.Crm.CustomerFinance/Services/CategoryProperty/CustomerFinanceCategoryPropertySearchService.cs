using Smafac.Crm.CustomerFinance.Applications.CategoryProperty;
using Smafac.Crm.CustomerFinance.Domain;
using Smafac.Crm.CustomerFinance.Domain.CategoryProperty;
using Smafac.Crm.CustomerFinance.Models;
using Smafac.Crm.CustomerFinance.Repository.CategoryProperty;
using Smafac.Framework.Core.Services.CategoryProperty;

namespace Smafac.Crm.CustomerFinance.Services.CategoryProperty
{
    class CustomerFinanceCategoryPropertySearchService : CategoryPropertySearchService<CustomerFinanceCategoryEntity, CustomerFinancePropertyEntity, CustomerFinancePropertyModel>,
                                                ICustomerFinanceCategoryPropertySearchService
    {
        public CustomerFinanceCategoryPropertySearchService(ICustomerFinanceCategoryPropertySearchRepository goodsCategoryPropertySearchRepository,
            ICustomerFinanceCategoryPropertyProvider goodsCategoryPropertyProvider
            )
        {
            base.CategoryAssociationProvider = goodsCategoryPropertyProvider;
            base.EntityAssociationSearchRepository = goodsCategoryPropertySearchRepository;
        }
    }
}
