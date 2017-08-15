using Smafac.Crm.Customer.Domain;
using Smafac.Crm.Customer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Repositories
{
    interface ICustomerPropertyRepository
    {
        bool AddProperty(CustomerPropertyEntity property);
        bool UpdateProperty(CustomerPropertyEntity property);
        bool DeleteProperty(Guid SubscriberId, Guid propertyId);
        List<CustomerPropertyEntity> GetProperties(Guid SubscriberId);
        List<CustomerPropertyModel> GetPropertyModels(Guid SubscriberId);
        CustomerPropertyEntity GetPropertyById(Guid SubscriberId,Guid propertyId);

    }
}
