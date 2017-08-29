using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Framework.Core.Applications.Property;
using Smafac.Sales.Order.Applications.Property;
using Smafac.Sales.Order.Models;

namespace Smafac.Sales.Order.Services.Property
{
    class OrderPropertyService : IOrderPropertyService
    {
        private readonly IOrderPropertyAddService _orderPropertyAddService;
        private readonly IOrderPropertyDeleteService _orderPropertyDeleteService;
        private readonly IOrderPropertySearchService _orderPropertySearchService;
        private readonly IOrderPropertyUpdateService _orderPropertyUpdateService;

        public OrderPropertyService(IOrderPropertyAddService orderPropertyAddService,
            IOrderPropertyDeleteService orderPropertyDeleteService,
            IOrderPropertySearchService orderPropertySearchService,
            IOrderPropertyUpdateService orderPropertyUpdateService)
        {
            _orderPropertyAddService = orderPropertyAddService;
            _orderPropertyDeleteService = orderPropertyDeleteService;
            _orderPropertySearchService = orderPropertySearchService;
            _orderPropertyUpdateService = orderPropertyUpdateService;
        }

        public IPropertyAddService<OrderPropertyModel> AddService => _orderPropertyAddService;

        public IPropertyDeleteService<OrderPropertyModel> DeleteService => _orderPropertyDeleteService;

        public IPropertyUpdateService<OrderPropertyModel> UpdateService => _orderPropertyUpdateService;

        public IPropertySearchService<OrderPropertyModel> SearchService => _orderPropertySearchService;
    }
}
