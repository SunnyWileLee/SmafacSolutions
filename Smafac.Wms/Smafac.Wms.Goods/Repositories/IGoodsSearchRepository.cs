using Smafac.Wms.Goods.Domain;
using Smafac.Wms.Goods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Repositories
{
    interface IGoodsSearchRepository
    {
        GoodsModel GetGoods(Guid subscriberId, Guid goodsId);
        List<GoodsModel> GetGoods(Guid subscriberId, Expression<Func<GoodsEntity, bool>> predicate);
    }
}
