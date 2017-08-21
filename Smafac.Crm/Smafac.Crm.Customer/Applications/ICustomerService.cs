using Smafac.Crm.Customer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Applications
{
    public interface ICustomerService
    {
        bool AddCustomer(CustomerModel model);
        bool UpdateCustomer(CustomerModel model);
        bool DeleteCustomer(Guid customerId);
        CustomerModel CreateEmptyCustomer();
    }
}
