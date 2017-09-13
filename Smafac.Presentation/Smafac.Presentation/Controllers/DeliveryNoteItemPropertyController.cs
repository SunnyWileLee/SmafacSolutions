using Smafac.Presentation.Domain;
using Smafac.Sales.DeliveryNote.Applications.ItemProperty;
using Smafac.Sales.DeliveryNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Smafac.Presentation.Controllers
{
    public class DeliveryNoteItemPropertyController : SmafacController
    {
        private readonly IDeliveryNoteItemPropertyService _itemPropertyService;
        private readonly IPropertyTypeProvider _propertyTypeProvider;

        public DeliveryNoteItemPropertyController(IDeliveryNoteItemPropertyService itemPropertyService,
                    IPropertyTypeProvider propertyTypeProvider)
        {
            _itemPropertyService = itemPropertyService;
            _propertyTypeProvider = propertyTypeProvider;
        }

        [HttpGet]
        public ActionResult DeliveryNoteItemPropertyView()
        {
            var types = _propertyTypeProvider.Provide();
            ViewData["types"] = types;
            var properties = _itemPropertyService.SearchService.GetColumns();
            return View(properties);
        }

        [HttpGet]
        public ActionResult DeliveryNoteItemPropertyAddView(Guid? propertyId)
        {
            var types = _propertyTypeProvider.Provide();
            ViewData["types"] = types;
            if (propertyId == null)
            {
                return View();
            }
            else
            {
                var property = _itemPropertyService.SearchService.GetColumn(propertyId.Value);
                return View(property);
            }
        }

        [HttpPost]
        public ActionResult AddDeliveryNoteItemProperty(DeliveryNoteItemPropertyModel model)
        {
            var result = _itemPropertyService.AddService.AddColumn(model);
            return BoolResult(result);
        }
        [HttpPost]
        public ActionResult EditDeliveryNoteItemProperty(DeliveryNoteItemPropertyModel model)
        {
            var result = _itemPropertyService.UpdateService.UpdateColumn(model);
            return BoolResult(result);
        }
        [HttpPost]
        public ActionResult DeleteDeliveryNoteItemProperty(Guid id)
        {
            var result = _itemPropertyService.DeleteService.DeleteColumn(id);
            return BoolResult(result);
        }
    }
}