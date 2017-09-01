using Smafac.Sales.Order.Applications;
using Smafac.Sales.Order.Applications.Charge;
using Smafac.Sales.Order.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Smafac.Presentation.Controllers
{
    public class OrderChargeController : SmafacController
    {
        private readonly IOrderChargeService _orderChargeService;
        private readonly IOrderChargeSearchService _orderChargeSearchService;

        public OrderChargeController(IOrderChargeService orderChargeService,
                                    IOrderChargeSearchService orderChargeSearchService)
        {
            _orderChargeService = orderChargeService;
            _orderChargeSearchService = orderChargeSearchService;
        }

        [HttpGet]
        public ActionResult OrderChargeView()
        {
            var properties = _orderChargeSearchService.GetCharges();
            return View(properties);
        }

        [HttpPost]
        public ActionResult AddOrderCharge(OrderChargeModel model)
        {
            var result = _orderChargeService.AddCharge(model);
            return BoolResult(result);
        }

        [HttpPost]
        public ActionResult DeleteOrderCharge(Guid id)
        {
            var result = _orderChargeService.DeleteCharge(id);
            return BoolResult(result);
        }
    }
}