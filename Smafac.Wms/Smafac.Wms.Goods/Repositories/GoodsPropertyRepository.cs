using Smafac.Framework.Core.Repositories;
using Smafac.Wms.Goods.Domain;
using Smafac.Wms.Goods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Repositories
{
    class GoodsPropertyRepository : PropertyRepository<GoodsContext, GoodsPropertyEntity>, IGoodsPropertyRepository
    {
        public GoodsPropertyRepository(IGoodsContextProvider goodsContextProvider)
        {
            base.ContextProvider = goodsContextProvider;
        }
    }
}
