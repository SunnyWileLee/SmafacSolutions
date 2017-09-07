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
        public OrderPropertyService(IOrderPropertyAddService orderPropertyAddService,
            IOrderPropertyDeleteService orderPropertyDeleteService,
            IOrderPropertySearchService orderPropertySearchService,
            IOrderPropertyUpdateService orderPropertyUpdateService)
        {
            AddService = orderPropertyAddService;
            DeleteService = orderPropertyDeleteService;
            SearchService = orderPropertySearchService;
            UpdateService = orderPropertyUpdateService;
        }

        public IOrderPropertyAddService AddService { get; set; }
        public IOrderPropertyDeleteService DeleteService { get; set; }
        public IOrderPropertySearchService SearchService { get; set; }
        public IOrderPropertyUpdateService UpdateService { get; set; }
    }
}
