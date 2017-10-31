using Smafac.Pms.Purchase.Domain;
using Smafac.Pms.Purchase.Models;
using System.Linq;

namespace Smafac.Pms.Purchase.Repositories.Joiners
{
    class PurchaseJoiner : IPurchaseJoiner
    {
        public IQueryable<PurchaseModel> Join(IQueryable<PurchaseEntity> purchases, IQueryable<PurchaseCategoryEntity> categories)
        {
            var query = from purchase in purchases
                        join category in categories on purchase.CategoryId equals category.Id
                        select new PurchaseModel
                        {
                            CategoryId = purchase.CategoryId,
                            SubscriberId = purchase.SubscriberId,
                            CategoryName = category.Name,
                            CreateTime = purchase.CreateTime,
                            Id = purchase.Id,
                            Amount = purchase.Amount,
                            GoodsId = purchase.GoodsId,
                            Quantity = purchase.Quantity
                        };
            return query;
        }
    }
}
