using Smafac.Framework.Core.Repositories.CategoryProperty;
using Smafac.Sales.Order.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Repositories.CategoryProperty
{
    class OrderCategoryPropertyBindRepository : CategoryPropertyBindRepository<OrderContext, OrderCategoryEntity, OrderPropertyEntity, OrderCategoryPropertyEntity>,
                                                IOrderCategoryPropertyBindRepository
    {
        public OrderCategoryPropertyBindRepository(IOrderContextProvider orderContextProvider)
        {
            base.ContextProvider = orderContextProvider;
        }
    }
}
