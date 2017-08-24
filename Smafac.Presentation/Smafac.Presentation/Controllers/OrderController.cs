using Smafac.Crm.Customer.Applications;
using Smafac.Presentation.Domain;
using Smafac.Sales.Order.Applications;
using Smafac.Sales.Order.Models;
using Smafac.Wms.Goods.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Smafac.Presentation.Controllers
{
    public class OrderController : SmafacController
    {
        private readonly IOrderService _orderService;
        private readonly IOrderSearchService _orderSearchService;
        private readonly IOrderWrapper[] _orderWrappers;

        public OrderController(IOrderService orderService,
                                IOrderSearchService orderSearchService,
                                IOrderWrapper[] orderWrappers
                                )
        {
            _orderService = orderService;
            _orderSearchService = orderSearchService;
            _orderWrappers = orderWrappers;
        }
        [HttpGet]
        public ActionResult OrderView()
        {
            return View();
        }
        [HttpGet]
        public ActionResult OrderPageView(OrderPageQueryModel model)
        {
            var page = _orderSearchService.GetOrderPage(model);
            var orders = page.PageData;
            if (orders.Any())
            {
                _orderWrappers.ToList().ForEach(wrapper =>
                {
                    wrapper.Wrapper(orders);
                });
            }
            return View(orders);
        }
        [HttpPost]
        public ActionResult OrderPage(OrderPageQueryModel model)
        {
            var page = _orderSearchService.GetOrderPage(model);
            return Success(page);
        }
        [HttpGet]
        public ActionResult OrderAddView()
        {
            OrderModel order = _orderService.CreateEmptyOrder();
            return View(order);
        }
        [HttpPost]
        public ActionResult AddOrder(OrderModel order)
        {
            var result = _orderService.AddOrder(order);
            return Success(result);
        }
        [HttpGet]
        public ActionResult OrderDetailView(Guid orderId)
        {
            var order = _orderSearchService.GetOrderDetail(orderId);
            return View(order);
        }
    }
}