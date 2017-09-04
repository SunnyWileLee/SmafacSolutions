using Smafac.Crm.CustomerFinance.Domain;
using Smafac.Crm.CustomerFinance.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Smafac.Crm.CustomerFinance.Repositories.Property
{
    interface ICustomerFinancePropertyValueRepository
    {
        bool AddPropertyValues(Guid financeId, IEnumerable<CustomerFinancePropertyValueEntity> values);
        bool UpdatePropertyValue(CustomerFinancePropertyValueModel model);
        List<CustomerFinancePropertyValueModel> GetPropertyValues(Guid subscriberId, Guid financeId);
        IEnumerable<IGrouping<Guid, CustomerFinancePropertyValueModel>> GetPropertyValues(Guid subscriberId, IEnumerable<Guid> financeIds);
        bool Any(Guid subscriberId, Guid propertyId);
        bool Delete(Guid subscriberId, Guid propertyId);
    }
}
