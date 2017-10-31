using Smafac.Framework.Core.Services.Category;
using Smafac.Pms.Purchase.Domain;
using Smafac.Pms.Purchase.Repositories.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Pms.Purchase.Services.Category
{
    class PurchaseCategoryInitialization : CategoryInitialization<PurchaseCategoryEntity>
    {
        public PurchaseCategoryInitialization(IPurchaseCategoryAddRepository goodsCategoryAddRepository,
                                        IPurchaseCategorySearchRepository goodsCategorySearchRepository
                                        )
        {
            base.CategoryAddRepository = goodsCategoryAddRepository;
            base.CategorySearchRepository = goodsCategorySearchRepository;
        }

        public override void Init(Guid subscriberId)
        {
            if (CategorySearchRepository.Any(subscriberId))
            {
                return;
            }
            IEnumerable<PurchaseCategoryEntity> categories = new List<PurchaseCategoryEntity> {
                new PurchaseCategoryEntity{
                    Name="产品",
                    SubscriberId=subscriberId,
                    Saleable=true,
                    Purchaseable=false
                },
                new PurchaseCategoryEntity{
                    Name="原料",
                    SubscriberId=subscriberId,
                    Saleable=false,
                    Purchaseable=true
                }
            };
            CategoryAddRepository.AddEntities(categories);
        }
    }
}
