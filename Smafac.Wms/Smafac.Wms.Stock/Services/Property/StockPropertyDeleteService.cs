using Smafac.Framework.Core.Services.Property;
using Smafac.Wms.Stock.Applications.Property;
using Smafac.Wms.Stock.Domain;
using Smafac.Wms.Stock.Domain.Property;
using Smafac.Wms.Stock.Models;
using Smafac.Wms.Stock.Repositories.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Stock.Services.Property
{
    class StockPropertyDeleteService : PropertyDeleteService<StockPropertyEntity, StockPropertyModel>, IStockPropertyDeleteService
    {
        public StockPropertyDeleteService(IStockPropertyDeleteRepository goodsPropertyDeleteRepository,
                                          IStockPropertySearchRepository goodsPropertySearchRepository,
                                          IStockPropertyUsedChecker[] goodsFinancePropertyUsedCheckers,
                                          IStockPropertyDeleteTrigger[] goodsPropertyDeleteTriggers)
        {
            base.CustomizedColumnDeleteRepository = goodsPropertyDeleteRepository;
            base.CustomizedColumnUsedCheckers = goodsFinancePropertyUsedCheckers;
            base.CustomizedColumnSearchRepository = goodsPropertySearchRepository;
            base.CustomizedColumnDeleteTriggers = goodsPropertyDeleteTriggers;
        }
    }
}
