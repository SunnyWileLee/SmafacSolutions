using Smafac.Presentation.Domain;
using Smafac.Wms.Stock.Applications.Property;
using Smafac.Wms.Stock.Models;
using System;
using System.Web.Mvc;

namespace Smafac.Presentation.Controllers
{
    public class StockPropertyController : SmafacController
    {
        private readonly IStockPropertyService _purchasePropertyService;
        private readonly IPropertyTypeProvider _propertyTypeProvider;

        public StockPropertyController(IStockPropertyService purchasePropertyService,
                    IPropertyTypeProvider propertyTypeProvider)
        {
            _purchasePropertyService = purchasePropertyService;
            _propertyTypeProvider = propertyTypeProvider;
        }

        [HttpGet]
        public ActionResult StockPropertyView()
        {
            var types = _propertyTypeProvider.Provide();
            ViewData["types"] = types;
            var properties = _purchasePropertyService.SearchService.GetColumns();
            return View(properties);
        }

        [HttpGet]
        public ActionResult StockPropertyAddView(Guid? propertyId)
        {
            var types = _propertyTypeProvider.Provide();
            ViewData["types"] = types;
            if (propertyId == null)
            {
                return View();
            }
            else
            {
                var property = _purchasePropertyService.SearchService.GetColumn(propertyId.Value);
                return View(property);
            }
        }

        [HttpPost]
        public ActionResult AddStockProperty(StockPropertyModel model)
        {
            var result = _purchasePropertyService.AddService.AddColumn(model);
            return BoolResult(result);
        }
        [HttpPost]
        public ActionResult EditStockProperty(StockPropertyModel model)
        {
            var result = _purchasePropertyService.UpdateService.UpdateColumn(model);
            return BoolResult(result);
        }
        [HttpPost]
        public ActionResult DeleteStockProperty(Guid id)
        {
            var result = _purchasePropertyService.DeleteService.DeleteColumn(id);
            return BoolResult(result);
        }
    }
}