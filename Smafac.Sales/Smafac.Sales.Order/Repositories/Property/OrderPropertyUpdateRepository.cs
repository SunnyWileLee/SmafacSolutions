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
    class OrderPropertyUpdateRepository : PropertyUpdateRepository<OrderContext, OrderPropertyEntity>, IOrderPropertyUpdateRepository
    {
        public OrderPropertyUpdateRepository(IOrderContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}
