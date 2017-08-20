using Smafac.Crm.Customer.Applications;
using Smafac.Crm.Customer.Models;
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

        public CustomerPropertyController(ICustomerPropertyService customerPropertyService)
        {
            _customerPropertyService = customerPropertyService;
        }

        [HttpGet]
        public ActionResult CustomerPropertyView()
        {
            var properties = _customerPropertyService.GetProperties();
            return View(properties);
        }

        [HttpPost]
        public ActionResult AddCustomerProperty(CustomerPropertyModel model)
        {
            var result = _customerPropertyService.AddProperty(model);
            return BoolResult(result);
        }

        [HttpPost]
        public ActionResult DeleteCustomerProperty(Guid id)
        {
            var result = _customerPropertyService.DeleteProperty(id);
            return BoolResult(result);
        }
    }
}