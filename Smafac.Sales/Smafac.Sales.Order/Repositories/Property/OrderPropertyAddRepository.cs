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
    class OrderPropertyAddRepository : PropertyAddRepository<OrderContext, OrderPropertyEntity>, IOrderPropertyAddRepository
    {
        public OrderPropertyAddRepository(IOrderContextProvider OrderContextProvider)
        {
            base.ContextProvider  = OrderContextProvider;
        }
    }
}
