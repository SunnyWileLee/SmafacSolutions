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
        private readonly IStockSearchRepository _searchRepository;
        private readonly IStockCategoryPropertyProvider _categoryPropertyProvider;

        public StockPropertyProvider(IStockSearchRepository searchRepository,
                                    IStockCategoryPropertyProvider categoryPropertyProvider
                                    )
        {
            _searchRepository = searchRepository;
            _categoryPropertyProvider = categoryPropertyProvider;
        }

        public List<StockPropertyModel> Provide(Guid goodsId)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var goods = _searchRepository.GetStock(subscriberId, goodsId);
            return _categoryPropertyProvider.ProvideAssociations(goods.CategoryId);
        }
    }
}
