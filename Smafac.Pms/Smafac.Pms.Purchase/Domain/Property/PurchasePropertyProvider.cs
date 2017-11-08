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
        private readonly IPurchaseSearchRepository _searchRepository;
        private readonly IPurchaseCategoryPropertyProvider _categoryPropertyProvider;

        public PurchasePropertyProvider(IPurchaseSearchRepository searchRepository,
                                    IPurchaseCategoryPropertyProvider categoryPropertyProvider
                                    )
        {
            _searchRepository = searchRepository;
            _categoryPropertyProvider = categoryPropertyProvider;
        }

        public List<PurchasePropertyModel> Provide(Guid goodsId)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var goods = _searchRepository.GetPurchase(subscriberId, goodsId);
            return _categoryPropertyProvider.ProvideAssociations(goods.CategoryId);
        }
    }
}
