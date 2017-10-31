using Smafac.Pms.Purchase.Domain;
using Smafac.Pms.Purchase.Models;
using System.Linq;

namespace Smafac.Pms.Purchase.Repositories.Joiners
{
    interface IPurchaseJoiner
    {
        IQueryable<PurchaseModel> Join(IQueryable<PurchaseEntity> goodses, IQueryable<PurchaseCategoryEntity> categories);
    }
}
