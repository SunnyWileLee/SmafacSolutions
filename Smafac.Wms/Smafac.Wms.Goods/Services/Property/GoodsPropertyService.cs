using Smafac.Wms.Goods.Applications.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Framework.Core.Applications.Property;
using Smafac.Wms.Goods.Models;

namespace Smafac.Wms.Goods.Services.Property
{
    class GoodsPropertyService : IGoodsPropertyService
    {
        public GoodsPropertyService(IGoodsPropertyAddService goodsPropertyAddService,
            IGoodsPropertyDeleteService goodsPropertyDeleteService,
            IGoodsPropertySearchService goodsPropertySearchService,
            IGoodsPropertyUpdateService goodsPropertyUpdateService)
        {
            AddService = goodsPropertyAddService;
            DeleteService = goodsPropertyDeleteService;
            SearchService = goodsPropertySearchService;
            UpdateService = goodsPropertyUpdateService;
        }

        public IGoodsPropertyAddService AddService { get; set; }
        public IGoodsPropertyDeleteService DeleteService { get; set; }
        public IGoodsPropertySearchService SearchService { get; set; }
        public IGoodsPropertyUpdateService UpdateService { get; set; }
    }
}
