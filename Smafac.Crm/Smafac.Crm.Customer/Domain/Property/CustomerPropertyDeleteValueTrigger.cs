﻿using Smafac.Crm.Customer.Repositories.PropertyValue;
using Smafac.Framework.Core.Domain.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Domain.Property
{
    class CustomerPropertyDeleteValueTrigger : PropertyDeleteValueTrigger<CustomerPropertyEntity, CustomerPropertyValueEntity>,
                                            ICustomerPropertyDeleteTrigger
    {
        public CustomerPropertyDeleteValueTrigger(ICustomerPropertyValueDeleteRepository customerPropertyValueDeleteRepository)
        {
            base.PropertyValueDeleteRepository = customerPropertyValueDeleteRepository;
        }
    }
}
