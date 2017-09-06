using Smafac.Framework.Core.Domain.Pages;
using Smafac.Wms.Goods.Models;

namespace Smafac.Wms.Goods.Domain.Pages
{
    interface IGoodsPageQueryer : IPageQueryer<GoodsModel, GoodsPageQueryModel>
    {
    }
}
