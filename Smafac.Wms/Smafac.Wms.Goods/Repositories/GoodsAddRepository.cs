using Smafac.Framework.Core.Repositories;
using Smafac.Wms.Goods.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Repositories
{
    class GoodsAddRepository : EntityAddRepository<GoodsContext, GoodsEntity>, IGoodsAddRepository
    {
        public GoodsAddRepository(IGoodsContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}
