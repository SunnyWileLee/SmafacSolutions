using Smafac.Crm.Customer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Applications
{
    public interface ICustomerContactPropertyService
    {
        bool AddProperty(CustomerContactPropertyModel model);
        bool UpdateProperty(CustomerContactPropertyModel model);
        bool DeleteProperty(Guid propertyId);
        List<CustomerContactPropertyModel> GetProperties();
    }
}
