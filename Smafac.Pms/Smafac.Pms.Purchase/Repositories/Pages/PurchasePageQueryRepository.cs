using Smafac.Framework.Core.Repositories.Pages;
using Smafac.Pms.Purchase.Domain;
using Smafac.Pms.Purchase.Models;
using Smafac.Pms.Purchase.Repositories.Joiners;
using System.Collections.Generic;
using System.Linq;

namespace Smafac.Pms.Purchase.Repositories.Pages
{
    class PurchasePageQueryRepository : PageQueryRepository<PurchaseContext, PurchaseEntity, PurchaseModel>
                                                , IPurchasePageQueryRepository
    {
        private readonly IPurchaseJoiner _goodsJoiner;

        public PurchasePageQueryRepository(IPurchaseContextProvider contextProvider,
                                        IPurchaseJoiner goodsJoiner)
        {
            base.ContextProvider = contextProvider;
            _goodsJoiner = goodsJoiner;
        }

        protected override List<PurchaseModel> SelectModel(IQueryable<PurchaseEntity> query, PurchaseContext context)
        {
            var models = _goodsJoiner.Join(query, context.PurchaseCategories);
            return models.ToList();
        }
    }
}
