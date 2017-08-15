using Smafac.Crm.Customer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Repositories
{
    interface ICustomerContactSearchRepository
    {
        List<CustomerContactModel> GetContactModels(Guid SubscriberId, Guid customerId);
        CustomerContactModel GetContactById(Guid SubscriberId, Guid contactId);
    }
}
