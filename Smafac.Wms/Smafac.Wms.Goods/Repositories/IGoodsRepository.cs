using Smafac.Wms.Goods.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Repositories
{
    interface IGoodsRepository
    {
        bool AddGoods(GoodsEntity goods);
    }
}
