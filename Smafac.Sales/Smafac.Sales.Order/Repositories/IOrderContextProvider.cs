using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Repositories
{
    interface IOrderContextProvider
    {
        OrderContext Provide();
        OrderContext ProvideSlave();
    }
}
