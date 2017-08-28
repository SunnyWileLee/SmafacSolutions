using Smafac.Sales.Order.Applications;
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
        private readonly IOrderPropertyService _goodsPropertyService;

        public OrderPropertyController(IOrderPropertyService goodsPropertyService)
        {
            _goodsPropertyService = goodsPropertyService;
        }

        [HttpGet]
        public ActionResult OrderPropertyView()
        {
            var properties = _goodsPropertyService.GetProperties();
            return View(properties);
        }

        [HttpPost]
        public ActionResult AddOrderProperty(OrderPropertyModel model)
        {
            var result = _goodsPropertyService.AddProperty(model);
            return BoolResult(result);
        }

        [HttpPost]
        public ActionResult DeleteOrderProperty(Guid id)
        {
            throw new NotImplementedException();
            //var result = _goodsPropertyService.DeleteProperty(id);
            //return BoolResult(result);
        }
    }
}