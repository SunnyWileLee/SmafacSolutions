using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Repositories
{
    class GoodsContextProvider : IGoodsContextProvider
    {
        public GoodsContext Provide()
        {
            return new GoodsContext();
        }

        public GoodsContext ProvideSlave()
        {
            return new GoodsContext();
        }
    }
}
