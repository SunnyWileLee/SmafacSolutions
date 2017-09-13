using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Smafac.Sales.DeliveryNote.Models;
using Smafac.Wms.Goods.Applications;

namespace Smafac.Presentation.Domain.DeliveryNote
{
    public class DeliveryNoteItemGoodsWrapper : IDeliveryNoteItemWrapper
    {
        private readonly IGoodsSearchService _goodsSearchService;

        public DeliveryNoteItemGoodsWrapper(IGoodsSearchService goodsSearchService)
        {
            _goodsSearchService = goodsSearchService;
        }

        public void Wrapper(List<DeliveryNoteItemModel> items)
        {
            if (!items.Any())
            {
                return;
            }
            var goodsIds = items.Select(s => s.GoodsId);
            var goodses = _goodsSearchService.GetGoods(goodsIds);
            items.ForEach(item =>
            {
                var goods = goodses.FirstOrDefault(s => s.Id == item.GoodsId);
                if (goods != null)
                {
                    item.GoodsName = goods.Name;
                }
            });
        }
    }
}