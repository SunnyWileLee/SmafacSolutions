using Smafac.Crm.CustomerFinance.Applications.Propety;
using Smafac.Crm.CustomerFinance.Models;
using Smafac.Presentation.Domain;
using System;
using System.Web.Mvc;

namespace Smafac.Presentation.Controllers
{
    public class CustomerFinancePropertyController : SmafacController
    {
        private readonly ICustomerFinancePropertyService _financePropertyService;
        private readonly IPropertyTypeProvider _propertyTypeProvider;

        public CustomerFinancePropertyController(ICustomerFinancePropertyService financePropertyService,
                                    IPropertyTypeProvider propertyTypeProvider
                                                )
        {
            _financePropertyService = financePropertyService;
            _propertyTypeProvider = propertyTypeProvider;
        }

        [HttpGet]
        public ActionResult CustomerFinancePropertyView()
        {
            var types = _propertyTypeProvider.Provide();
            ViewData["types"] = types;
            var properties = _financePropertyService.SearchService.GetColumns();
            return View(properties);
        }

        [HttpPost]
        public ActionResult AddCustomerFinanceProperty(CustomerFinancePropertyModel model)
        {
            var result = _financePropertyService.AddService.AddColumn(model);
            return BoolResult(result);
        }

        [HttpPost]
        public ActionResult DeleteCustomerFinanceProperty(Guid id)
        {
            var result = _financePropertyService.DeleteService.DeleteColumn(id);
            return BoolResult(result);
        }
    }
}