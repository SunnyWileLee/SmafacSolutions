using Smafac.Crm.Customer.Domain;
using Smafac.Framework.Core.Repositories.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Repositories.Property
{
    class CustomerPropertyAddRepository : PropertyAddRepository<CustomerContext, CustomerPropertyEntity>, ICustomerPropertyAddRepository
    {
        public CustomerPropertyAddRepository(ICustomerContextProvider contextProvider)
        {
            base.ContextProvider  = contextProvider;
        }
    }
}
