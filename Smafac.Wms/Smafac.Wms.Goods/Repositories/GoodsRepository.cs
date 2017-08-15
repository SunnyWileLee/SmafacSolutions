using Smafac.Wms.Goods.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Repositories
{
    class GoodsRepository : IGoodsRepository
    {
        private readonly IGoodsContextProvider _goodsContextProvider;

        public GoodsRepository(IGoodsContextProvider goodsContextProvider)
        {
            _goodsContextProvider = goodsContextProvider;
        }

        public bool AddGoods(GoodsEntity goods)
        {
            using (var context = _goodsContextProvider.Provide())
            {
                context.Goods.Add(goods);
                return context.SaveChanges() > 0;
            }
        }
    }
}
