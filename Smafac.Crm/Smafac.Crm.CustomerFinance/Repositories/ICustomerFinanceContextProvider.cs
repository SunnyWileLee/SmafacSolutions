using Smafac.Framework.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.CustomerFinance.Repositories
{
    interface ICustomerFinanceContextProvider: IDbContextProvider<CustomerFinanceContext>
    {
    }
}
