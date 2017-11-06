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
        private readonly IStockSearchRepository _goodsSearchRepository;
        private readonly IStockPropertyValueSearchRepository _goodsPropertyValueSearchRepository;
        private readonly IStockPageQueryer _goodsPageQueryer;

        public StockSearchService(IStockSearchRepository goodsSearchRepository,
                                    IStockPropertyValueSearchRepository goodsPropertyValueSearchRepository,
                                    IStockPageQueryer goodsPageQueryer
                                    )
        {
            _goodsSearchRepository = goodsSearchRepository;
            _goodsPropertyValueSearchRepository = goodsPropertyValueSearchRepository;
            _goodsPageQueryer = goodsPageQueryer;
        }

        public List<StockModel> GetStock(IEnumerable<Guid> goodsIds)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            Expression<Func<StockEntity, bool>> predicate = s => goodsIds.Contains(s.Id);
            return _goodsSearchRepository.GetStock(subscriberId, predicate);
        }

        public StockModel GetStock(Guid goodsId)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var goods = _goodsSearchRepository.GetStock(subscriberId, goodsId);
            var properties = _goodsPropertyValueSearchRepository.GetPropertyValues(subscriberId, goodsId);
            goods.Properties = properties;
            return goods;
        }

        public List<StockModel> GetStock(StockPageQueryModel query)
        {
            return _goodsPageQueryer.Query(query);
        }

        public StockDetailModel GetStockDetail(Guid goodsId)
        {
            var goods = this.GetStock(goodsId);
            return new StockDetailModel { Stock = goods };
        }


        public PageModel<StockModel> GetStockPage(StockPageQueryModel query)
        {
            return _goodsPageQueryer.QueryPage(query);
        }
    }
}
