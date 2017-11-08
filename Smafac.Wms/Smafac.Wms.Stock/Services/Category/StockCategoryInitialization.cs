using Smafac.Framework.Core.Services.Category;
using Smafac.Wms.Stock.Domain;
using Smafac.Wms.Stock.Repositories.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Stock.Services.Category
{
    class StockCategoryInitialization : CategoryInitialization<StockCategoryEntity>
    {
        public StockCategoryInitialization(IStockCategoryAddRepository categoryAddRepository,
                                        IStockCategorySearchRepository categorySearchRepository
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
            IEnumerable<StockCategoryEntity> categories = new List<StockCategoryEntity> {
                new StockCategoryEntity{
                    Name="当前库存",
                    SubscriberId=subscriberId
                },
                new StockCategoryEntity{
                    Name="出库记录",
                    SubscriberId=subscriberId
                },
                new StockCategoryEntity{
                    Name="入库记录",
                    SubscriberId=subscriberId
                },
            };
            CategoryAddRepository.AddEntities(categories);
        }
    }
}
