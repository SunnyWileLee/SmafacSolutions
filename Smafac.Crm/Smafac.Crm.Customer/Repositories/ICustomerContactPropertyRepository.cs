using Smafac.Crm.Customer.Domain;
using Smafac.Crm.Customer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Repositories
{
    interface ICustomerContactPropertyRepository
    {
        bool AddProperty(CustomerContactPropertyEntity property);
        bool UpdateProperty(CustomerContactPropertyEntity property);
        bool DeleteProperty(Guid SubscriberId, Guid propertyId);
        List<CustomerContactPropertyEntity> GetProperties(Guid SubscriberId);
        List<CustomerContactPropertyModel> GetPropertyModels(Guid SubscriberId);
        CustomerContactPropertyEntity GetPropertyById(Guid SubscriberId, Guid propertyId);

    }
}
