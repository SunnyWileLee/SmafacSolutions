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
        ICustomerUpdateService UpdateService { get; set; }
        bool AddCustomer(CustomerModel model);
        bool DeleteCustomer(Guid customerId);
        CustomerModel CreateEmptyCustomer();
    }
}
