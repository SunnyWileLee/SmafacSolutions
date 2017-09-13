using Smafac.Presentation.Domain;
using Smafac.Sales.DeliveryNote.Applications.Property;
using Smafac.Sales.DeliveryNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Smafac.Presentation.Controllers
{
    public class DeliveryNotePropertyController : SmafacController
    {
        private readonly IDeliveryNotePropertyService _notePropertyService;
        private readonly IPropertyTypeProvider _propertyTypeProvider;

        public DeliveryNotePropertyController(IDeliveryNotePropertyService notePropertyService,
                    IPropertyTypeProvider propertyTypeProvider)
        {
            _notePropertyService = notePropertyService;
            _propertyTypeProvider = propertyTypeProvider;
        }

        [HttpGet]
        public ActionResult DeliveryNotePropertyView()
        {
            var types = _propertyTypeProvider.Provide();
            ViewData["types"] = types;
            var properties = _notePropertyService.SearchService.GetColumns();
            return View(properties);
        }

        [HttpGet]
        public ActionResult DeliveryNotePropertyAddView(Guid? propertyId)
        {
            var types = _propertyTypeProvider.Provide();
            ViewData["types"] = types;
            if (propertyId == null)
            {
                return View();
            }
            else
            {
                var property = _notePropertyService.SearchService.GetColumn(propertyId.Value);
                return View(property);
            }
        }

        [HttpPost]
        public ActionResult AddDeliveryNoteProperty(DeliveryNotePropertyModel model)
        {
            var result = _notePropertyService.AddService.AddColumn(model);
            return BoolResult(result);
        }
        [HttpPost]
        public ActionResult EditDeliveryNoteProperty(DeliveryNotePropertyModel model)
        {
            var result = _notePropertyService.UpdateService.UpdateColumn(model);
            return BoolResult(result);
        }
        [HttpPost]
        public ActionResult DeleteDeliveryNoteProperty(Guid id)
        {
            var result = _notePropertyService.DeleteService.DeleteColumn(id);
            return BoolResult(result);
        }
    }
}