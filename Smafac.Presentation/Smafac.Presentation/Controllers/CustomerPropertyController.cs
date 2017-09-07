using Smafac.Crm.Customer.Applications;
using Smafac.Crm.Customer.Applications.Propety;
using Smafac.Crm.Customer.Models;
using Smafac.Presentation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Smafac.Presentation.Controllers
{
    public class CustomerPropertyController : SmafacController
    {
        private readonly ICustomerPropertyService _customerPropertyService;
        private readonly IPropertyTypeProvider _propertyTypeProvider;

        public CustomerPropertyController(ICustomerPropertyService customerPropertyService,
                    IPropertyTypeProvider propertyTypeProvider)
        {
            _customerPropertyService = customerPropertyService;
            _propertyTypeProvider = propertyTypeProvider;
        }

        [HttpGet]
        public ActionResult CustomerPropertyView()
        {
            var types = _propertyTypeProvider.Provide();
            ViewData["types"] = types;
            var properties = _customerPropertyService.SearchService.GetColumns();
            return View(properties);
        }

        [HttpPost]
        public ActionResult AddCustomerProperty(CustomerPropertyModel model)
        {
            var result = _customerPropertyService.AddService.AddColumn(model);
            return BoolResult(result);
        }

        [HttpPost]
        public ActionResult DeleteCustomerProperty(Guid id)
        {
            var result = _customerPropertyService.DeleteService.DeleteColumn(id);
            return BoolResult(result);
        }
    }
}