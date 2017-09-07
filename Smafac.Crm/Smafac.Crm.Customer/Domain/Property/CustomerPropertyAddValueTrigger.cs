using Smafac.Crm.Customer.Repositories;
using Smafac.Crm.Customer.Repositories.PropertyValue;
using Smafac.Framework.Core.Domain.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Domain.Property
{

    class CustomerPropertyAddValueTrigger : PropertyAddValueTrigger<CustomerPropertyEntity, CustomerPropertyValueEntity, CustomerEntity>,
                                            ICustomerPropertyAddTrigger
    {
        public CustomerPropertyAddValueTrigger(ICustomerPropertyValueSetRepository propertyValueSetRepository,
                                               ICustomerSearchRepository searchRepository)
        {
            base.PropertyValueSetRepository = propertyValueSetRepository;
            base.EntitySearchRepository = searchRepository;
        }

        protected override void ModifyValue(CustomerPropertyValueEntity value, Guid customerId, CustomerPropertyEntity property)
        {
            base.ModifyValue(value, customerId, property);
            value.CustomerId = customerId;
        }
    }
}
