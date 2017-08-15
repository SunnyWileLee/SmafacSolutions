using Smafac.Crm.Customer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Repositories
{
    interface ICustomerRepository
    {
        bool AddCustomer(CustomerEntity customer);
        bool UpdateCustomer(CustomerEntity customer);
        bool DeleteCustomer(Guid SubscriberId, Guid customerId);
    }
}
