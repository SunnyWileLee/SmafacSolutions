using Smafac.Crm.CustomerFinance.Domain;
using Smafac.Framework.Core.Repositories.PropertyValue;
using System;
using System.Linq;

namespace Smafac.Crm.CustomerFinance.Repositories.PropertyValue
{
    class CustomerFinancePropertyValueSetRepository : PropertyValueSetRepository<CustomerFinanceContext, CustomerFinancePropertyValueEntity>
                                                , ICustomerFinancePropertyValueSetRepository
    {
        public CustomerFinancePropertyValueSetRepository(ICustomerFinanceContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }

        protected override bool HasSetValue(IQueryable<CustomerFinancePropertyValueEntity> values, Guid entityId)
        {
            return values.Any(s => s.CustomerFinanceId.Equals(entityId));
        }

        protected override bool VerifyEntityId(Guid entityId, CustomerFinancePropertyValueEntity value)
        {
            return !entityId.Equals(value.CustomerFinanceId);
        }
    }
}
