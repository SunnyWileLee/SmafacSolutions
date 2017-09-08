using Smafac.Presentation.Domain;
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
        private readonly IPropertyTypeProvider _propertyTypeProvider;

        public OrderPropertyController(IOrderPropertyService orderPropertyService,
                    IPropertyTypeProvider propertyTypeProvider)
        {
            _orderPropertyService = orderPropertyService;
            _propertyTypeProvider = propertyTypeProvider;
        }

        [HttpGet]
        public ActionResult OrderPropertyView()
        {
            var types = _propertyTypeProvider.Provide();
            ViewData["types"] = types;
            var properties = _orderPropertyService.SearchService.GetColumns();
            return View(properties);
        }

        [HttpGet]
        public ActionResult OrderPropertyAddView(Guid? propertyId)
        {
            var types = _propertyTypeProvider.Provide();
            ViewData["types"] = types;
            if (propertyId == null)
            {
                return View();
            }
            else
            {
                var property = _orderPropertyService.SearchService.GetColumn(propertyId.Value);
                return View(property);
            }
        }

        [HttpPost]
        public ActionResult AddOrderProperty(OrderPropertyModel model)
        {
            var result = _orderPropertyService.AddService.AddColumn(model);
            return BoolResult(result);
        }
        [HttpPost]
        public ActionResult EditOrderProperty(OrderPropertyModel model)
        {
            var result = _orderPropertyService.UpdateService.UpdateColumn(model);
            return BoolResult(result);
        }

        [HttpPost]
        public ActionResult DeleteOrderProperty(Guid id)
        {
            var result = _orderPropertyService.DeleteService.DeleteColumn(id);
            return BoolResult(result);
        }
    }
}