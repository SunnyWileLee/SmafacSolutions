using Smafac.Framework.Core.Repositories.Category;
using Smafac.Sales.Order.Domain;
using Smafac.Sales.Order.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Repositories.Category
{
    class OrderCategoryUpdateRepository : CategoryUpdateRepository<OrderContext, OrderCategoryEntity>, IOrderCategoryUpdateRepository
    {
        public OrderCategoryUpdateRepository(IOrderContextProvider OrderContextProvider)
        {
            base.ContextProvider = OrderContextProvider;
        }
    }
}
