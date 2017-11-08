using Smafac.Framework.Core.Repositories;
using Smafac.Pms.Purchase.Domain;
using Smafac.Pms.Purchase.Models;
using Smafac.Pms.Purchase.Repositories.Joiners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Pms.Purchase.Repositories
{
    class PurchaseSearchRepository : EntitySearchRepository<PurchaseContext, PurchaseEntity>, IPurchaseSearchRepository
    {
        private readonly IPurchaseJoiner _goodsJoiner;

        public PurchaseSearchRepository(IPurchaseContextProvider contextProvider,
                                    IPurchaseJoiner goodsJoiner)
        {
            base.ContextProvider = contextProvider;
            _goodsJoiner = goodsJoiner;
        }

        public List<PurchaseModel> GetPurchase(Guid subscriberId, Expression<Func<PurchaseEntity, bool>> predicate)
        {
            using (var context = ContextProvider.Provide())
            {
                var goodses = context.Purchases.Where(s => s.SubscriberId == subscriberId).Where(predicate);
                return _goodsJoiner.Join(goodses, context.PurchaseCategories).ToList();
            }
        }

        public PurchaseModel GetPurchase(Guid subscriberId, Guid goodsId)
        {
            using (var context = ContextProvider.Provide())
            {
                var goodses = context.Purchases.Where(s => s.SubscriberId == subscriberId && s.Id == goodsId);
                return _goodsJoiner.Join(goodses, context.PurchaseCategories).FirstOrDefault();
            }
        }
    }
}
