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
        public PurchaseCategoryInitialization(IPurchaseCategoryAddRepository categoryAddRepository,
                                        IPurchaseCategorySearchRepository categorySearchRepository
                                        )
        {
            base.CategoryAddRepository = categoryAddRepository;
            base.CategorySearchRepository = categorySearchRepository;
        }

        public override void Init(Guid subscriberId)
        {
            if (CategorySearchRepository.Any(subscriberId))
            {
                return;
            }
            IEnumerable<PurchaseCategoryEntity> categories = new List<PurchaseCategoryEntity> {
                new PurchaseCategoryEntity{
                    Name="默认",
                    SubscriberId=subscriberId
                }
            };
            CategoryAddRepository.AddEntities(categories);
        }
    }
}
