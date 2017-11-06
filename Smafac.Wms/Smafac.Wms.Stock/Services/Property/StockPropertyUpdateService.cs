using Smafac.Framework.Core.Services.Property;
using Smafac.Wms.Stock.Applications.Property;
using Smafac.Wms.Stock.Domain;
using Smafac.Wms.Stock.Models;
using Smafac.Wms.Stock.Repositories.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Stock.Services.Property
{
    class StockPropertyUpdateService : PropertyUpdateService<StockPropertyEntity, StockPropertyModel>, IStockPropertyUpdateService
    {
        public StockPropertyUpdateService(IStockPropertySearchRepository goodsPropertySearchRepository,
                                          IStockPropertyUpdateRepository goodsPropertyUpdateRepository)
        {
            base.CustomizedColumnSearchRepository = goodsPropertySearchRepository;
            base.CustomizedColumnUpdateRepository = goodsPropertyUpdateRepository;
        }
    }
}
