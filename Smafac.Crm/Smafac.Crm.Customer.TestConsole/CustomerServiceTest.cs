using Smafac.Crm.Customer.Applications;
using Smafac.Crm.Customer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.TestConsole
{
    class CustomerServiceTest
    {
        private readonly ICustomerService _customerService;
        private readonly Guid _newId = Guid.NewGuid();
        public CustomerServiceTest(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public bool AddCustomer()
        {
            var model = new CustomerModel
              {
                  Id = _newId,
                  Address = "江苏昆山",
                  KnownDate = DateTime.Now,
                  LevelId = Guid.Empty,
                  MobileNumber = "15900000000",
                  Name = "江都电子有限公司"
              };
            return _customerService.AddCustomer(model);
        }

        public bool UpdateCustomer()
        {
            var model = new CustomerModel
            {
                Id = _newId,
                Address = "江苏昆山",
                KnownDate = DateTime.Now,
                LevelId = Guid.Empty,
                MobileNumber = "15900000000",
                Name = "江都电子有限公司2"
            };
            return _customerService.UpdateCustomer(model);
        }
        public bool DeleteCustomer()
        {
            return true;
        }
    }
}
