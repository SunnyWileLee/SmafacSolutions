using Smafac.Crm.CustomerFinance.Applications.Propety;
using Smafac.Crm.CustomerFinance.Model;
using Smafac.Framework.Core.Applications.Property;

namespace Smafac.Crm.CustomerFinance.Services.Property
{
    class CustomerFinancePropertyService : ICustomerFinancePropertyService
    {
        private readonly ICustomerFinancePropertyAddService _goodsPropertyAddService;
        private readonly ICustomerFinancePropertyDeleteService _goodsPropertyDeleteService;
        private readonly ICustomerFinancePropertySearchService _goodsPropertySearchService;
        private readonly ICustomerFinancePropertyUpdateService _goodsPropertyUpdateService;

        public CustomerFinancePropertyService(ICustomerFinancePropertyAddService goodsPropertyAddService,
            ICustomerFinancePropertyDeleteService goodsPropertyDeleteService,
            ICustomerFinancePropertySearchService goodsPropertySearchService,
            ICustomerFinancePropertyUpdateService goodsPropertyUpdateService)
        {
            _goodsPropertyAddService = goodsPropertyAddService;
            _goodsPropertyDeleteService = goodsPropertyDeleteService;
            _goodsPropertySearchService = goodsPropertySearchService;
            _goodsPropertyUpdateService = goodsPropertyUpdateService;
        }

        public IPropertyAddService<CustomerFinancePropertyModel> AddService => _goodsPropertyAddService;

        public IPropertyDeleteService<CustomerFinancePropertyModel> DeleteService => _goodsPropertyDeleteService;

        public IPropertyUpdateService<CustomerFinancePropertyModel> UpdateService => _goodsPropertyUpdateService;

        public IPropertySearchService<CustomerFinancePropertyModel> SearchService => _goodsPropertySearchService;
    }
}
