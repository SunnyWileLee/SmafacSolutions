using Smafac.Wms.Goods.Applications;
using Smafac.Wms.Stock.Models;
using System.Collections.Generic;
using System.Linq;

namespace Smafac.Presentation.Domain.Purchase
{
    public class StockGoodsWrapper : IStockWrapper
    {
        private readonly IGoodsSearchService _goodsSearchService;

        public StockGoodsWrapper(IGoodsSearchService goodsSearchService)
        {
            _goodsSearchService = goodsSearchService;
        }

        public void Wrapper(List<StockModel> stocks)
        {
            if (!stocks.Any())
            {
                return;
            }
            var goodsIds = stocks.Select(s => s.GoodsId);
            var goodses = _goodsSearchService.GetGoods(goodsIds);
            stocks.ForEach(order =>
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