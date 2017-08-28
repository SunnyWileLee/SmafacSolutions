using Smafac.Framework.Core.Repositories.Property;
using Smafac.Wms.Goods.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Repositories.Property
{
    class GoodsPropertyDeleteRepository : PropertyDeleteRepository<GoodsContext, GoodsPropertyEntity>, IGoodsPropertyDeleteRepository
    {
        public GoodsPropertyDeleteRepository(IGoodsContextProvider goodsContextProvider)
        {
            base.ContextProvider = goodsContextProvider;
        }
    }
}
