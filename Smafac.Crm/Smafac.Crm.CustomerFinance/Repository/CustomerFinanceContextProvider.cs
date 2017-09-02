using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.CustomerFinance.Repository
{
    class CustomerFinanceContextProvider : ICustomerFinanceContextProvider
    {
        public CustomerFinanceContext Provide()
        {
            return new CustomerFinanceContext();
        }

        public CustomerFinanceContext ProvideSlave()
        {
            return new CustomerFinanceContext();
        }
    }
}
