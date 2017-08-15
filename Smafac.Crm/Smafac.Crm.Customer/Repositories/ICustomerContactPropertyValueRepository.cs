using Smafac.Crm.Customer.Domain;
using Smafac.Crm.Customer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Repositories
{
    interface ICustomerContactPropertyValueRepository
    {
        bool SetPropertyValue(CustomerContactPropertyValueEntity value);
        List<CustomerContactPropertyValueModel> GetPropertyValues(Guid SubscriberId, Guid contactId);
    }
}
