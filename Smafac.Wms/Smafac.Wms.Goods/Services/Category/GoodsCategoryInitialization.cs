using Smafac.Framework.Core.Services.Category;
using Smafac.Wms.Goods.Domain;
using Smafac.Wms.Goods.Repositories.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Services.Category
{
    class GoodsCategoryInitialization : CategoryInitialization<GoodsCategoryEntity>
    {
        public GoodsCategoryInitialization(IGoodsCategoryAddRepository goodsCategoryAddRepository,
                                        IGoodsCategorySearchRepository goodsCategorySearchRepository
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
            IEnumerable<GoodsCategoryEntity> categories = new List<GoodsCategoryEntity> {
                new GoodsCategoryEntity{
                    Name="产品",
                    SubscriberId=subscriberId
                },
                new GoodsCategoryEntity{
                    Name="原料",
                    SubscriberId=subscriberId
                }
            };
            CategoryAddRepository.AddEntities(categories);
        }
    }
}
