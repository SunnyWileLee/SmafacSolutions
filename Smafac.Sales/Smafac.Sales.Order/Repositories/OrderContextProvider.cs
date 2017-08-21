using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Repositories
{
    class OrderContextProvider : IOrderContextProvider
    {
        public OrderContext Provide()
        {
            return new OrderContext();
        }

        public OrderContext ProvideSlave()
        {
            return new OrderContext();
        }
    }
}
