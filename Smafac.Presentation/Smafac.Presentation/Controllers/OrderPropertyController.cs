using Smafac.Sales.Order.Applications;
using Smafac.Sales.Order.Applications.Property;
using Smafac.Sales.Order.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Smafac.Presentation.Controllers
{
    public class OrderPropertyController : SmafacController
    {
        private readonly IOrderPropertyService _orderPropertyService;

        public OrderPropertyController(IOrderPropertyService orderPropertyService)
        {
            _orderPropertyService = orderPropertyService;
        }

        [HttpGet]
        public ActionResult OrderPropertyView()
        {
            var properties = _orderPropertyService.SearchService.GetProperties();
            return View(properties);
        }

        [HttpPost]
        public ActionResult AddOrderProperty(OrderPropertyModel model)
        {
            var result = _orderPropertyService.AddService.AddProperty(model);
            return BoolResult(result);
        }

        [HttpPost]
        public ActionResult DeleteOrderProperty(Guid id)
        {
            var result = _orderPropertyService.DeleteService.DeleteProperty(id);
            return BoolResult(result);
        }
    }
}