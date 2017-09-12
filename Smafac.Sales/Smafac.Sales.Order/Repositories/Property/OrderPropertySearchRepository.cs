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
    class OrderPropertySearchRepository : PropertySearchRepository<OrderContext, OrderPropertyEntity>, IOrderPropertySearchRepository
    {
        public OrderPropertySearchRepository(IOrderContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}
