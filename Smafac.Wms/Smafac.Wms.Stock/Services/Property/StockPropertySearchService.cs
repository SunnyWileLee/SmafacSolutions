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
    class StockPropertySearchService : PropertySearchService<StockPropertyEntity, StockPropertyModel>, IStockPropertySearchService
    {
        private readonly IStockPropertyProvider _goodsPropertyProvider;

        public StockPropertySearchService(IStockPropertySearchRepository goodsSearchRepository,
            IStockPropertyProvider goodsPropertyProvider)
        {
            base.CustomizedColumnSearchRepository = goodsSearchRepository;
            _goodsPropertyProvider = goodsPropertyProvider;
        }

        public override List<StockPropertyModel> GetColumns(Guid entityId)
        {
            return _goodsPropertyProvider.Provide(entityId);
        }
    }
}
