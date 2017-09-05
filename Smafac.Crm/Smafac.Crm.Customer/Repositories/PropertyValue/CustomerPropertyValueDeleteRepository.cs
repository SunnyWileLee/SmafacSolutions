using Smafac.Crm.Customer.Domain;
using Smafac.Framework.Core.Repositories.PropertyValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Repositories.PropertyValue
{
    class CustomerPropertyValueDeleteRepository : PropertyValueDeleteRepository<CustomerContext, CustomerPropertyValueEntity>,
                                                ICustomerPropertyValueDeleteRepository
    {

        public CustomerPropertyValueDeleteRepository(ICustomerContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}
