using Smafac.Wms.Stock.Applications.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Wms.Stock.Models;
using Smafac.Framework.Core.Services.Property;
using Smafac.Wms.Stock.Domain;
using Smafac.Wms.Stock.Repositories.Property;

namespace Smafac.Wms.Stock.Services.Property
{
    class StockPropertyAddService : PropertyAddService<StockPropertyEntity, StockPropertyModel>, IStockPropertyAddService
    {
        public StockPropertyAddService(IStockPropertyAddRepository goodsPropertyAddRepository,
                                        IStockPropertySearchRepository goodsPropertySearchRepository)
        {
            base.CustomizedColumnAddRepository = goodsPropertyAddRepository;
            base.CustomizedColumnSearchRepository = goodsPropertySearchRepository;
        }
    }
}
