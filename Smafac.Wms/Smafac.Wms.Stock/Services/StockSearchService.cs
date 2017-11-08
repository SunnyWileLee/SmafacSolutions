using Smafac.Framework.Core.Models;
using Smafac.Wms.Stock.Applications;
using Smafac.Wms.Stock.Domain;
using Smafac.Wms.Stock.Domain.Pages;
using Smafac.Wms.Stock.Models;
using Smafac.Wms.Stock.Repositories;
using Smafac.Wms.Stock.Repositories.PropertyValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Smafac.Wms.Stock.Services
{
    class StockSearchService : IStockSearchService
    {
        private readonly IStockSearchRepository _searchRepository;
        private readonly IStockPropertyValueSearchRepository _propertyValueSearchRepository;
        private readonly IStockPageQueryer _pageQueryer;

        public StockSearchService(IStockSearchRepository searchRepository,
                                    IStockPropertyValueSearchRepository propertyValueSearchRepository,
                                    IStockPageQueryer pageQueryer
                                    )
        {
            _searchRepository = searchRepository;
            _propertyValueSearchRepository = propertyValueSearchRepository;
            _pageQueryer = pageQueryer;
        }

        public List<StockModel> GetStock(IEnumerable<Guid> goodsIds)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            Expression<Func<StockEntity, bool>> predicate = s => goodsIds.Contains(s.Id);
            return _searchRepository.GetStock(subscriberId, predicate);
        }

        public StockModel GetStock(Guid goodsId)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var goods = _searchRepository.GetStock(subscriberId, goodsId);
            var properties = _propertyValueSearchRepository.GetPropertyValues(subscriberId, goodsId);
            goods.Properties = properties;
            return goods;
        }

        public List<StockModel> GetStock(StockPageQueryModel query)
        {
            return _pageQueryer.Query(query);
        }

        public StockDetailModel GetStockDetail(Guid goodsId)
        {
            var goods = this.GetStock(goodsId);
            return new StockDetailModel { Stock = goods };
        }


        public PageModel<StockModel> GetStockPage(StockPageQueryModel query)
        {
            return _pageQueryer.QueryPage(query);
        }
    }
}
