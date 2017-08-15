using Smafac.Crm.Customer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Applications
{
    public interface ICustomerPropertyService
    {
        bool AddProperty(CustomerPropertyModel model);
        bool UpdateProperty(CustomerPropertyModel model);
        bool DeleteProperty(Guid propertyId);
        List<CustomerPropertyModel> GetProperties();
    }
}
