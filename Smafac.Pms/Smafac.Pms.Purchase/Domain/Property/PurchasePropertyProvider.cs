using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Framework.Core.Models;
using Smafac.Pms.Purchase.Repositories;
using Smafac.Framework.Core.Models;
using Smafac.Pms.Purchase.Models;
using Smafac.Pms.Purchase.Domain.CategoryProperty;

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
