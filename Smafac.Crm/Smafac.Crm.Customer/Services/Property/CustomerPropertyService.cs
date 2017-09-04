using Smafac.Crm.Customer.Applications.Propety;
using Smafac.Crm.Customer.Models;
using Smafac.Framework.Core.Applications.Property;

namespace Smafac.Crm.Customer.Services.Property
{
    class CustomerPropertyService : ICustomerPropertyService
    {
        private readonly ICustomerPropertyAddService _goodsPropertyAddService;
        private readonly ICustomerPropertyDeleteService _goodsPropertyDeleteService;
        private readonly ICustomerPropertySearchService _goodsPropertySearchService;
        private readonly ICustomerPropertyUpdateService _goodsPropertyUpdateService;

        public CustomerPropertyService(ICustomerPropertyAddService goodsPropertyAddService,
            ICustomerPropertyDeleteService goodsPropertyDeleteService,
            ICustomerPropertySearchService goodsPropertySearchService,
            ICustomerPropertyUpdateService goodsPropertyUpdateService)
        {
            _goodsPropertyAddService = goodsPropertyAddService;
            _goodsPropertyDeleteService = goodsPropertyDeleteService;
            _goodsPropertySearchService = goodsPropertySearchService;
            _goodsPropertyUpdateService = goodsPropertyUpdateService;
        }

        public IPropertyAddService<CustomerPropertyModel> AddService => _goodsPropertyAddService;

        public IPropertyDeleteService<CustomerPropertyModel> DeleteService => _goodsPropertyDeleteService;

        public IPropertyUpdateService<CustomerPropertyModel> UpdateService => _goodsPropertyUpdateService;

        public IPropertySearchService<CustomerPropertyModel> SearchService => _goodsPropertySearchService;
    }
}
