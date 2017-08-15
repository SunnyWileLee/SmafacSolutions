using Smafac.Crm.Customer.Domain;
using Smafac.Crm.Customer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Repositories
{
    interface ICustomerPropertyValueRepository
    {
        bool SetPropertyValue(CustomerPropertyValueEntity value);
        List<CustomerPropertyValueModel> GetPropertyValues(Guid SubscriberId,Guid customerId);
    }
}
