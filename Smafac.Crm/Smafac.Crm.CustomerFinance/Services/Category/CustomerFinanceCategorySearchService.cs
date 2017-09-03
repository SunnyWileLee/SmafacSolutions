using Smafac.Crm.CustomerFinance.Applications.Category;
using Smafac.Crm.CustomerFinance.Domain;
using Smafac.Crm.CustomerFinance.Domain.Property;
using Smafac.Crm.CustomerFinance.Models;
using Smafac.Crm.CustomerFinance.Repository.Category;
using Smafac.Framework.Core.Services.Category;

namespace Smafac.Crm.CustomerFinance.Services.Category
{
    class CustomerFinanceCategorySearchService : CategorySearchService<CustomerFinanceCategoryEntity, CustomerFinanceCategoryModel>, 
                                                ICustomerFinanceCategorySearchService
    {
        public CustomerFinanceCategorySearchService(ICustomerFinanceCategorySearchRepository goodsSearchRepository,
            ICustomerFinancePropertyProvider goodsCategoryProvider)
        {
            base.CategorySearchRepository = goodsSearchRepository;
        }
    }
}
