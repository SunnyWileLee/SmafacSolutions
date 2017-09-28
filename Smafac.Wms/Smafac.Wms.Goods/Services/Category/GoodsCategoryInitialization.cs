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
    }
}
