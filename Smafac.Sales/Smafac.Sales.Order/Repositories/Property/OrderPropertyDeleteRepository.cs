using Smafac.Framework.Core.Repositories.Property;
using Smafac.Sales.Order.Domain;
using Smafac.Sales.Order.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Repositories.Property
{
    class OrderPropertyDeleteRepository : PropertyDeleteRepository<OrderContext, OrderPropertyEntity>, IOrderPropertyDeleteRepository
    {
        public OrderPropertyDeleteRepository(IOrderContextProvider orderContextProvider)
        {
            base.ContextProvider = orderContextProvider;
        }
    }
}
