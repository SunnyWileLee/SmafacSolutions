using Smafac.Crm.Customer.Domain;
using Smafac.Framework.Core.Repositories.PropertyValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Repositories.PropertyValue
{
    class CustomerPropertyValueSetRepository : PropertyValueSetRepository<CustomerContext, CustomerPropertyValueEntity>
                                                , ICustomerPropertyValueSetRepository
    {
        public CustomerPropertyValueSetRepository(ICustomerContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }

        protected override bool HasSetValue(IQueryable<CustomerPropertyValueEntity> values, Guid entityId)
        {
            return values.Any(s => s.CustomerId.Equals(entityId));
        }

        protected override bool VerifyEntityId(Guid entityId, CustomerPropertyValueEntity value)
        {
            return !entityId.Equals(value.CustomerId);
        }
    }
}
