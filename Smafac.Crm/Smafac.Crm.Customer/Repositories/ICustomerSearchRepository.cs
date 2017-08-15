using Smafac.Crm.Customer.Domain;
using Smafac.Crm.Customer.Models;
using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Repositories
{
    interface ICustomerSearchRepository
    {
        CustomerEntity GetById(Guid SubscriberId, Guid customerId);
        List<CustomerModel> GetCustomerPage(CustomerPageQueryModel query);
        int GetCustomerCount(CustomerPageQueryModel query);
    }
}
