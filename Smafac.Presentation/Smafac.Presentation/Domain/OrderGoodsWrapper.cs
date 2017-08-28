﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Smafac.Sales.Order.Models;
using Smafac.Wms.Goods.Applications;

namespace Smafac.Presentation.Domain
{
    public class OrderGoodsWrapper : IOrderWrapper
    {
        private readonly IGoodsSearchService _goodsSearchService;

        public OrderGoodsWrapper(IGoodsSearchService goodsSearchService)
        {
            _goodsSearchService = goodsSearchService;
        }

        public void Wrapper(List<OrderModel> orders)
        {
            if (!orders.Any())
            {
                return;
            }
            var orderIds = orders.Select(s => s.Id);
            var goodses = _goodsSearchService.GetGoods(orderIds);
            orders.ForEach(order =>
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