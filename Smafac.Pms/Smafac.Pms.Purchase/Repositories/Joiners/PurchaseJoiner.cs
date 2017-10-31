using Smafac.Pms.Purchase.Domain;
using Smafac.Pms.Purchase.Models;
using System.Linq;

namespace Smafac.Pms.Purchase.Repositories.Joiners
{
    class PurchaseJoiner : IPurchaseJoiner
    {
        public IQueryable<PurchaseModel> Join(IQueryable<PurchaseEntity> goodses, IQueryable<PurchaseCategoryEntity> categories)
        {
            var query = from goods in goodses
                        join category in categories on goods.CategoryId equals category.Id
                        select new PurchaseModel
                        {
                            CategoryId = goods.CategoryId,
                            SubscriberId = goods.SubscriberId,
                            CategoryName = category.Name,
                            CreateTime = goods.CreateTime,
                            Id = goods.Id,
                            Name = goods.Name,
                            Price = goods.Price,
                            Saleable = category.Saleable,
                            Purchaseable = category.Purchaseable
                        };
            return query;
        }
    }
}
