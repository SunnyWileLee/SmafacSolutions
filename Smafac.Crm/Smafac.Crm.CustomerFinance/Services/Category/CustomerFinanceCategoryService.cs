using Smafac.Crm.CustomerFinance.Applications.Category;
using Smafac.Crm.CustomerFinance.Models;
using Smafac.Framework.Core.Applications.Category;

namespace Smafac.Crm.CustomerFinance.Services.Category
{
    class CustomerFinanceCategoryService : ICustomerFinanceCategoryService
    {
        private readonly ICustomerFinanceCategoryAddService _goodsCategoryAddService;
        private readonly ICustomerFinanceCategoryDeleteService _goodsCategoryDeleteService;
        private readonly ICustomerFinanceCategorySearchService _goodsCategorySearchService;
        private readonly ICustomerFinanceCategoryUpdateService _goodsCategoryUpdateService;

        public CustomerFinanceCategoryService(ICustomerFinanceCategoryAddService goodsCategoryAddService,
            ICustomerFinanceCategoryDeleteService goodsCategoryDeleteService,
            ICustomerFinanceCategorySearchService goodsCategorySearchService,
            ICustomerFinanceCategoryUpdateService goodsCategoryUpdateService)
        {
            _goodsCategoryAddService = goodsCategoryAddService;
            _goodsCategoryDeleteService = goodsCategoryDeleteService;
            _goodsCategorySearchService = goodsCategorySearchService;
            _goodsCategoryUpdateService = goodsCategoryUpdateService;
        }

        public ICategoryAddService<CustomerFinanceCategoryModel> AddService => _goodsCategoryAddService;

        public ICategoryDeleteService<CustomerFinanceCategoryModel> DeleteService => _goodsCategoryDeleteService;

        public ICategoryUpdateService<CustomerFinanceCategoryModel> UpdateService => _goodsCategoryUpdateService;

        public ICategorySearchService<CustomerFinanceCategoryModel> SearchService => _goodsCategorySearchService;
    }
}
