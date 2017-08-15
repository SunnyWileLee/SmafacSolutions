using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Repositories
{
    interface ICustomerContextProvider
    {
        CustomerContext Provide();
        CustomerContext ProvideSlave();
    }
}
