using Smafac.Framework.Core.Repositories;
using Smafac.Pms.Purchase.Domain;
using Smafac.Pms.Purchase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Pms.Purchase.Repositories
{
    interface IPurchaseSearchRepository : IEntitySearchRepository<PurchaseEntity>
    {
        PurchaseModel GetPurchase(Guid subscriberId, Guid goodsId);
        List<PurchaseModel> GetPurchase(Guid subscriberId, Expression<Func<PurchaseEntity, bool>> predicate);
    }
}
