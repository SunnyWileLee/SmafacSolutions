using Smafac.Crm.Customer.Applications;
using Smafac.Crm.Customer.Models;
using Smafac.Framework.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Smafac.Crm.Customer.WebApi.Controllers
{
    [UserContextFilter]
    public class CustomerController : ApiController
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpPost]
        public bool AddCustomer(CustomerModel model)
        {
            return _customerService.AddCustomer(model);
        }
    }
}