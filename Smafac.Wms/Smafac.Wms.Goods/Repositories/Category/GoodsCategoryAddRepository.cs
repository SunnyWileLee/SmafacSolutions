using Smafac.Framework.Core.Repositories.Category;
using Smafac.Wms.Goods.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Repositories.Category
{
    class GoodsCategoryAddRepository : CategoryAddRepository<GoodsContext, GoodsCategoryEntity>, IGoodsCategoryAddRepository
    {
        public GoodsCategoryAddRepository(IGoodsContextProvider goodsContextProvider)
        {
            base.ContextProvider  = goodsContextProvider;
        }
    }
}
