using Smafac.Crm.CustomerFinance.Applications.Propety;
using Smafac.Crm.CustomerFinance.Models;
using System;
using System.Web.Mvc;

namespace Smafac.Presentation.Controllers
{
    public class CustomerFinancePropertyController : SmafacController
    {
        private readonly ICustomerFinancePropertyService _financePropertyService;

        public CustomerFinancePropertyController(ICustomerFinancePropertyService financePropertyService)
        {
            _financePropertyService = financePropertyService;
        }

        [HttpGet]
        public ActionResult CustomerFinancePropertyView()
        {
            var properties = _financePropertyService.SearchService.GetProperties();
            return View(properties);
        }

        [HttpPost]
        public ActionResult AddCustomerFinanceProperty(CustomerFinancePropertyModel model)
        {
            var result = _financePropertyService.AddService.AddProperty(model);
            return BoolResult(result);
        }

        [HttpPost]
        public ActionResult DeleteCustomerFinanceProperty(Guid id)
        {
            var result = _financePropertyService.DeleteService.DeleteProperty(id);
            return BoolResult(result);
        }
    }
}