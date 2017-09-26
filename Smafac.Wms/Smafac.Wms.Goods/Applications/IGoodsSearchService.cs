using Smafac.Framework.Models;
using Smafac.Wms.Goods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Applications
{
    public interface IGoodsSearchService
    {
        GoodsModel GetGoods(Guid goodsId);
        GoodsDetailModel GetGoodsDetail(Guid goodsId);
        List<GoodsModel> GetGoods(string key);
        PageModel<GoodsModel> GetGoodsPage(GoodsPageQueryModel query);
        List<GoodsModel> GetGoods(GoodsPageQueryModel query);
        List<GoodsModel> GetGoods(IEnumerable<Guid> goodsIds);
    }
}
