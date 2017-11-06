using Smafac.Framework.Core.Models;
using Smafac.Wms.Stock.Domain.CategoryProperty;
using Smafac.Wms.Stock.Models;
using Smafac.Wms.Stock.Repositories;
using System;
using System.Collections.Generic;

namespace Smafac.Wms.Stock.Domain.Property
{
    class StockPropertyProvider : IStockPropertyProvider
    {
        private readonly IStockSearchRepository _goodsSearchRepository;
        private readonly IStockCategoryPropertyProvider _goodsCategoryPropertyProvider;

        public StockPropertyProvider(IStockSearchRepository goodsSearchRepository,
                                    IStockCategoryPropertyProvider goodsCategoryPropertyProvider
                                    )
        {
            _goodsSearchRepository = goodsSearchRepository;
            _goodsCategoryPropertyProvider = goodsCategoryPropertyProvider;
        }

        public List<StockPropertyModel> Provide(Guid goodsId)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var goods = _goodsSearchRepository.GetStock(subscriberId, goodsId);
            return _goodsCategoryPropertyProvider.ProvideAssociations(goods.CategoryId);
        }
    }
}
