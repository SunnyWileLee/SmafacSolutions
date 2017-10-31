using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Smafac.Pms.Purchase.Models;
using Smafac.Wms.Goods.Applications;

namespace Smafac.Presentation.Domain.Purchase
{
    public class PurchaseGoodsWrapper : IPurchaseWrapper
    {
        private readonly IGoodsSearchService _goodsSearchService;

        public PurchaseGoodsWrapper(IGoodsSearchService goodsSearchService)
        {
            _goodsSearchService = goodsSearchService;
        }

        public void Wrapper(List<PurchaseModel> purchases)
        {
            if (!purchases.Any())
            {
                return;
            }
            var goodsIds = purchases.Select(s => s.GoodsId);
            var goodses = _goodsSearchService.GetGoods(goodsIds);
            purchases.ForEach(order =>
            {
                var goods = goodses.FirstOrDefault(s => s.Id == order.GoodsId);
                if (goods != null)
                {
                    order.GoodsName = goods.Name;
                }
            });
        }
    }
}