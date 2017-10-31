using Smafac.Framework.Core.Models;
using Smafac.Pms.Purchase.Domain.CategoryProperty;
using Smafac.Pms.Purchase.Models;
using Smafac.Pms.Purchase.Repositories;
using System;
using System.Collections.Generic;

namespace Smafac.Pms.Purchase.Domain.Property
{
    class PurchasePropertyProvider : IPurchasePropertyProvider
    {
        private readonly IPurchaseSearchRepository _goodsSearchRepository;
        private readonly IPurchaseCategoryPropertyProvider _goodsCategoryPropertyProvider;

        public PurchasePropertyProvider(IPurchaseSearchRepository goodsSearchRepository,
                                    IPurchaseCategoryPropertyProvider goodsCategoryPropertyProvider
                                    )
        {
            _goodsSearchRepository = goodsSearchRepository;
            _goodsCategoryPropertyProvider = goodsCategoryPropertyProvider;
        }

        public List<PurchasePropertyModel> Provide(Guid goodsId)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var goods = _goodsSearchRepository.GetPurchase(subscriberId, goodsId);
            return _goodsCategoryPropertyProvider.ProvideAssociations(goods.CategoryId);
        }
    }
}
