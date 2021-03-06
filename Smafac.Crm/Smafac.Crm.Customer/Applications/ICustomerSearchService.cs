﻿using Smafac.Crm.Customer.Models;
using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Applications
{
    public interface ICustomerSearchService
    {
        CustomerDetailModel GetCustomerDetail(Guid customerId);
        PageModel<CustomerModel> GetCustomerPage(CustomerPageQueryModel query);
        List<CustomerModel> GetCustomers(CustomerPageQueryModel query);
        CustomerModel GetCustomer(Guid customerId);
        List<CustomerModel> GetCustomers(IEnumerable<Guid> customerIds);
        List<CustomerModel> GetCustomers();
    }
}
