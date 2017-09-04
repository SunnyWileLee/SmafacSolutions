using Smafac.Crm.Customer.Domain;
using Smafac.Crm.Customer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Smafac.Crm.Customer.Repositories.Property
{
    interface ICustomerPropertyValueRepository
    {
        bool AddPropertyValues(Guid customerId, IEnumerable<CustomerPropertyValueEntity> values);
        bool UpdatePropertyValue(CustomerPropertyValueModel model);
        List<CustomerPropertyValueModel> GetPropertyValues(Guid subscriberId, Guid customerId);
        IEnumerable<IGrouping<Guid, CustomerPropertyValueModel>> GetPropertyValues(Guid subscriberId, IEnumerable<Guid> customerIds);
        bool Any(Guid subscriberId, Guid propertyId);
        bool Delete(Guid subscriberId, Guid propertyId);
    }
}
