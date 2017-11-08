using Smafac.Framework.Core.Models;
using Smafac.Pms.Purchase.Applications;
using Smafac.Pms.Purchase.Domain;
using Smafac.Pms.Purchase.Domain.Pages;
using Smafac.Pms.Purchase.Models;
using Smafac.Pms.Purchase.Repositories;
using Smafac.Pms.Purchase.Repositories.PropertyValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Smafac.Pms.Purchase.Services
{
    class PurchaseSearchService : IPurchaseSearchService
    {
        private readonly IPurchaseSearchRepository _searchRepository;
        private readonly IPurchasePropertyValueSearchRepository _propertyValueSearchRepository;
        private readonly IPurchasePageQueryer _pageQueryer;

        public PurchaseSearchService(IPurchaseSearchRepository searchRepository,
                                    IPurchasePropertyValueSearchRepository propertyValueSearchRepository,
                                    IPurchasePageQueryer pageQueryer
                                    )
        {
            _searchRepository = searchRepository;
            _propertyValueSearchRepository = propertyValueSearchRepository;
            _pageQueryer = pageQueryer;
        }

        public List<PurchaseModel> GetPurchase(IEnumerable<Guid> goodsIds)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            Expression<Func<PurchaseEntity, bool>> predicate = s => goodsIds.Contains(s.Id);
            return _searchRepository.GetPurchase(subscriberId, predicate);
        }

        public PurchaseModel GetPurchase(Guid goodsId)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var goods = _searchRepository.GetPurchase(subscriberId, goodsId);
            var properties = _propertyValueSearchRepository.GetPropertyValues(subscriberId, goodsId);
            goods.Properties = properties;
            return goods;
        }

        public List<PurchaseModel> GetPurchase(PurchasePageQueryModel query)
        {
            return _pageQueryer.Query(query);
        }

        public PurchaseDetailModel GetPurchaseDetail(Guid goodsId)
        {
            var goods = this.GetPurchase(goodsId);
            return new PurchaseDetailModel { Purchase = goods };
        }


        public PageModel<PurchaseModel> GetPurchasePage(PurchasePageQueryModel query)
        {
            return _pageQueryer.QueryPage(query);
        }
    }
}
