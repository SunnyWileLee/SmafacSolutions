using Smafac.Crm.Customer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Repositories
{
    interface ICustomerContactRepository
    {
        bool AddContact(CustomerContactEntity contact);
        bool UpdateContact(CustomerContactEntity contact);
        bool DeleteContact(Guid SubscriberId, Guid contactId);
    }
}
