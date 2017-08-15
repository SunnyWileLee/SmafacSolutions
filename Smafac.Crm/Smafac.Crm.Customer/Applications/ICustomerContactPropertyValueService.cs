using Smafac.Crm.Customer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Applications
{
    interface ICustomerContactPropertyValueService
    {
        bool SetPropertyValue(CustomerContactPropertyValueModel model);
        List<CustomerContactPropertyValueModel> GetPropertyValues(Guid contactId);
    }
}
