using Smafac.Framework.Core.Models;
using Smafac.Framework.Core.Models;
using Smafac.Pms.Purchase.Applications;
using Smafac.Pms.Purchase.Domain;
using Smafac.Pms.Purchase.Models;
using Smafac.Pms.Purchase.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using AutoMapper;
using System.Threading.Tasks;
using Smafac.Framework.Core.Repositories.Query;
using Smafac.Pms.Purchase.Repositories.PropertyValue;
using Smafac.Pms.Purchase.Repositories.Property;
using Smafac.Pms.Purchase.Domain.Pages;

namespace Smafac.Pms.Purchase.Services
{
    class PurchaseSearchService : IPurchaseSearchService
    {
        private readonly IPurchaseSearchRepository _goodsSearchRepository;
        private readonly IPurchasePropertyValueSearchRepository _goodsPropertyValueSearchRepository;
        private readonly IPurchasePageQueryer _goodsPageQueryer;

        public PurchaseSearchService(IPurchaseSearchRepository goodsSearchRepository,
                                    IPurchasePropertyValueSearchRepository goodsPropertyValueSearchRepository,
                                    IPurchasePageQueryer goodsPageQueryer
                                    )
        {
            _goodsSearchRepository = goodsSearchRepository;
            _goodsPropertyValueSearchRepository = goodsPropertyValueSearchRepository;
            _goodsPageQueryer = goodsPageQueryer;
        }

        public List<PurchaseModel> GetPurchase(string key)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            Expression<Func<PurchaseEntity, bool>> predicate = s => s.Name.Contains(key);
            return _goodsSearchRepository.GetPurchase(subscriberId, predicate);
        }

        public List<PurchaseModel> GetPurchase(IEnumerable<Guid> goodsIds)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            Expression<Func<PurchaseEntity, bool>> predicate = s => goodsIds.Contains(s.Id);
            return _goodsSearchRepository.GetPurchase(subscriberId, predicate);
        }

        public PurchaseModel GetPurchase(Guid goodsId)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var goods = _goodsSearchRepository.GetPurchase(subscriberId, goodsId);
            var properties = _goodsPropertyValueSearchRepository.GetPropertyValues(subscriberId, goodsId);
            goods.Properties = properties;
            return goods;
        }

        public List<PurchaseModel> GetPurchase(PurchasePageQueryModel query)
        {
            return _goodsPageQueryer.Query(query);
        }

        public PurchaseDetailModel GetPurchaseDetail(Guid goodsId)
        {
            var goods = this.GetPurchase(goodsId);
            return new PurchaseDetailModel { Purchase = goods };
        }


        public PageModel<PurchaseModel> GetPurchasePage(PurchasePageQueryModel query)
        {
            return _goodsPageQueryer.QueryPage(query);
        }
    }
}
