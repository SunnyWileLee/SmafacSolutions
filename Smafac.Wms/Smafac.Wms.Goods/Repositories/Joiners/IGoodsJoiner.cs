using Smafac.Wms.Goods.Domain;
using Smafac.Wms.Goods.Models;
using System.Linq;

namespace Smafac.Wms.Goods.Repositories.Joiners
{
    interface IGoodsJoiner
    {
        IQueryable<GoodsModel> Join(IQueryable<GoodsEntity> goodses, IQueryable<GoodsCategoryEntity> categories);
    }
}
