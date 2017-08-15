using Smafac.Crm.Customer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Applications
{
    public interface ICustomerPropertyValueService
    {
        bool SetPropertyValue(CustomerPropertyValueModel model);
        List<CustomerPropertyValueModel> GetPropertyValues(Guid customerId);
    }
}
