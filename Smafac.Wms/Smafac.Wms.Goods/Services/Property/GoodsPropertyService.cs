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
        private readonly IGoodsPropertyAddService _goodsPropertyAddService;
        private readonly IGoodsPropertyDeleteService _goodsPropertyDeleteService;
        private readonly IGoodsPropertySearchService _goodsPropertySearchService;
        private readonly IGoodsPropertyUpdateService _goodsPropertyUpdateService;

        public GoodsPropertyService(IGoodsPropertyAddService goodsPropertyAddService,
            IGoodsPropertyDeleteService goodsPropertyDeleteService,
            IGoodsPropertySearchService goodsPropertySearchService,
            IGoodsPropertyUpdateService goodsPropertyUpdateService)
        {
            _goodsPropertyAddService = goodsPropertyAddService;
            _goodsPropertyDeleteService = goodsPropertyDeleteService;
            _goodsPropertySearchService = goodsPropertySearchService;
            _goodsPropertyUpdateService = goodsPropertyUpdateService;
        }

        public IPropertyAddService<GoodsPropertyModel> AddService => _goodsPropertyAddService;

        public IPropertyDeleteService<GoodsPropertyModel> DeleteService => _goodsPropertyDeleteService;

        public IPropertyUpdateService<GoodsPropertyModel> UpdateService => _goodsPropertyUpdateService;

        public IPropertySearchService<GoodsPropertyModel> SearchService => _goodsPropertySearchService;
    }
}
