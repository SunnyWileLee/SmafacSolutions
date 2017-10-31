using Smafac.Pms.Purchase.Applications.Property;
using Smafac.Pms.Purchase.Models;
using Smafac.Presentation.Domain;
using System;
using System.Web.Mvc;

namespace Smafac.Presentation.Controllers
{
    public class PurchasePropertyController : SmafacController
    {
        private readonly IPurchasePropertyService _purchasePropertyService;
        private readonly IPropertyTypeProvider _propertyTypeProvider;

        public PurchasePropertyController(IPurchasePropertyService purchasePropertyService,
                    IPropertyTypeProvider propertyTypeProvider)
        {
            _purchasePropertyService = purchasePropertyService;
            _propertyTypeProvider = propertyTypeProvider;
        }

        [HttpGet]
        public ActionResult PurchasePropertyView()
        {
            var types = _propertyTypeProvider.Provide();
            ViewData["types"] = types;
            var properties = _purchasePropertyService.SearchService.GetColumns();
            return View(properties);
        }

        [HttpGet]
        public ActionResult PurchasePropertyAddView(Guid? propertyId)
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
        public ActionResult AddPurchaseProperty(PurchasePropertyModel model)
        {
            var result = _purchasePropertyService.AddService.AddColumn(model);
            return BoolResult(result);
        }
        [HttpPost]
        public ActionResult EditPurchaseProperty(PurchasePropertyModel model)
        {
            var result = _purchasePropertyService.UpdateService.UpdateColumn(model);
            return BoolResult(result);
        }
        [HttpPost]
        public ActionResult DeletePurchaseProperty(Guid id)
        {
            var result = _purchasePropertyService.DeleteService.DeleteColumn(id);
            return BoolResult(result);
        }
    }
}