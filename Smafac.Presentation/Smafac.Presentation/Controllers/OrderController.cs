using Smafac.Crm.Customer.Applications;
using Smafac.Presentation.Domain;
using Smafac.Sales.Order.Applications;
using Smafac.Sales.Order.Applications.Category;
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
        private readonly IGoodsSearchService _goodsSearchService;
        private readonly ICustomerSearchService _customerSearchService;
        private readonly IOrderCategorySearchService _orderCategorySearchService;

        public OrderController(IOrderService orderService,
                                IOrderSearchService orderSearchService,
                                IOrderWrapper[] orderWrappers,
                                IGoodsSearchService goodsSearchService,
                                ICustomerSearchService customerSearchService,
                                IOrderCategorySearchService orderCategorySearchService
                                )
        {
            _orderService = orderService;
            _orderSearchService = orderSearchService;
            _orderWrappers = orderWrappers;
            _goodsSearchService = goodsSearchService;
            _customerSearchService = customerSearchService;
            _orderCategorySearchService = orderCategorySearchService;
        }
        [HttpGet]
        public ActionResult OrderView()
        {
            var customers = _customerSearchService.GetCustomers();
            var categories = _orderCategorySearchService.GetCategories();
            ViewData["customers"] = customers.Select(s => new SelectListItem { Text = s.Name, Value = s.Id.ToString() });
            ViewData["categories"] = categories.Select(s => new SelectListItem { Text = s.Name, Value = s.Id.ToString() });
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
            ViewData["tableColumns"] = page.TableColumns;
            ViewData["chargeColumns"] = page.ChargeTableColumns;
            return View(orders);
        }
        [HttpPost]
        public ActionResult OrderPage(OrderPageQueryModel model)
        {
            var page = _orderSearchService.GetOrderPage(model);
            return Success(page);
        }
        [HttpGet]
        public ActionResult OrderAddView(Guid goodsId)
        {
            var goods = _goodsSearchService.GetGoods(goodsId);
            var customers = _customerSearchService.GetCustomers().Select(s => new SelectListItem { Text = s.Name, Value = s.Id.ToString() });
            ViewData["customers"] = customers;
            var categories = _orderCategorySearchService.GetCategories().Select(s => new SelectListItem { Text = s.Name, Value = s.Id.ToString() }).OrderBy(s => s.Text);
            ViewData["categories"] = categories;
            OrderModel order = _orderService.CreateEmptyOrder();
            order.GoodsId = goods.Id;
            order.GoodsName = goods.Name;
            order.Price = goods.Price;
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
            _orderWrappers.ToList().ForEach(wrapper =>
            {
                wrapper.Wrapper(new List<OrderModel> { order.Order });
            });
            return View(order);
        }
    }
}