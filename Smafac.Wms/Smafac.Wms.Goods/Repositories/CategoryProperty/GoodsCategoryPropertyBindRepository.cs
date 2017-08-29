using Smafac.Framework.Core.Repositories.CategoryProperty;
using Smafac.Wms.Goods.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Repositories.CategoryProperty
{
    class GoodsCategoryPropertyBindRepository : CategoryPropertyBindRepository<GoodsContext, GoodsCategoryEntity, GoodsPropertyEntity, GoodsCategoryPropertyEntity>,
                                                IGoodsCategoryPropertyBindRepository
    {
        public GoodsCategoryPropertyBindRepository(IGoodsContextProvider goodsContextProvider)
        {
            base.ContextProvider = goodsContextProvider;
        }
    }
}
