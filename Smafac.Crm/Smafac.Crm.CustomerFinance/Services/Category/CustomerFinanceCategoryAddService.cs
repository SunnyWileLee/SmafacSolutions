using Smafac.Crm.CustomerFinance.Applications.Category;
using Smafac.Crm.CustomerFinance.Domain;
using Smafac.Crm.CustomerFinance.Models;
using Smafac.Crm.CustomerFinance.Repositories.Category;
using Smafac.Framework.Core.Services.Category;

namespace Smafac.Crm.CustomerFinance.Services.Category
{
    class CustomerFinanceCategoryAddService : CategoryAddService<CustomerFinanceCategoryEntity, CustomerFinanceCategoryModel>, 
                                                ICustomerFinanceCategoryAddService
    {
        public CustomerFinanceCategoryAddService(ICustomerFinanceCategoryAddRepository goodsCategoryAddRepository,
                                        ICustomerFinanceCategorySearchRepository goodsCategorySearchRepository)
        {
            base.CategoryAddRepository = goodsCategoryAddRepository;
            base.CategorySearchRepository = goodsCategorySearchRepository;
        }
    }
}
