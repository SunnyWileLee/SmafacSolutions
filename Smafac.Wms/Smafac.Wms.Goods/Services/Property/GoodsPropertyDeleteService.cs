using Smafac.Framework.Core.Services.Property;
using Smafac.Wms.Goods.Applications.Property;
using Smafac.Wms.Goods.Domain;
using Smafac.Wms.Goods.Domain.Property;
using Smafac.Wms.Goods.Models;
using Smafac.Wms.Goods.Repositories.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Services.Property
{
    class GoodsPropertyDeleteService : PropertyDeleteService<GoodsPropertyEntity, GoodsPropertyModel>, IGoodsPropertyDeleteService
    {
        public GoodsPropertyDeleteService(IGoodsPropertyDeleteRepository goodsPropertyDeleteRepository,
                                          IGoodsPropertySearchRepository goodsPropertySearchRepository,
                                          IGoodsPropertyUsedChecker[] goodsFinancePropertyUsedCheckers,
                                          IGoodsPropertyDeleteTrigger[] goodsPropertyDeleteTriggers)
        {
            base.PropertyDeleteRepository = goodsPropertyDeleteRepository;
            base.PropertyUsedCheckers = goodsFinancePropertyUsedCheckers;
            base.PropertySearchRepository = goodsPropertySearchRepository;
            base.PropertyDeleteTriggers = goodsPropertyDeleteTriggers;
        }
    }
}
