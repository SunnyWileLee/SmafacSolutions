using Smafac.Pms.Purchase.Applications.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Framework.Core.Applications.Property;
using Smafac.Pms.Purchase.Models;

namespace Smafac.Pms.Purchase.Services.Property
{
    class PurchasePropertyService : IPurchasePropertyService
    {
        public PurchasePropertyService(IPurchasePropertyAddService goodsPropertyAddService,
            IPurchasePropertyDeleteService goodsPropertyDeleteService,
            IPurchasePropertySearchService goodsPropertySearchService,
            IPurchasePropertyUpdateService goodsPropertyUpdateService)
        {
            AddService = goodsPropertyAddService;
            DeleteService = goodsPropertyDeleteService;
            SearchService = goodsPropertySearchService;
            UpdateService = goodsPropertyUpdateService;
        }

        public IPurchasePropertyAddService AddService { get; set; }
        public IPurchasePropertyDeleteService DeleteService { get; set; }
        public IPurchasePropertySearchService SearchService { get; set; }
        public IPurchasePropertyUpdateService UpdateService { get; set; }
    }
}
