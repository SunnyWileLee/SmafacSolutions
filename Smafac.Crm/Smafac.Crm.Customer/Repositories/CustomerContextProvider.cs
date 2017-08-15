using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Repositories
{
    class CustomerContextProvider : ICustomerContextProvider
    {
        public CustomerContext Provide()
        {
            return new CustomerContext();
        }

        public CustomerContext ProvideSlave()
        {
            return new CustomerContext();
        }
    }
}
