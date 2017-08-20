using Smafac.Crm.Customer.Applications;
using Smafac.Crm.Customer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Smafac.Presentation.Controllers
{
    public class CustomerController : SmafacController
    {
        private readonly ICustomerSearchService _customerSearchService;
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerSearchService customerSearchService,
                                    ICustomerService customerService)
        {
            _customerSearchService = customerSearchService;
            _customerService = customerService;
        }

        [HttpGet]
        public ActionResult CustomerView()
        {
            return View();
        }
        [HttpGet]
        public ActionResult CustomerPageView(CustomerPageQueryModel query)
        {
            var page = _customerSearchService.GetCustomerPage(query);
            return View(page.PageData);
        }
        [HttpGet]
        public ActionResult CustomerDetailView(Guid customerId)
        {
            var customer = _customerSearchService.GetCustomerDetail(customerId);
            return View(customer);
        }
        [HttpGet]
        public ActionResult CustomerAddView()
        {
            return View();
        }
    }
}