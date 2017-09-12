using Smafac.Framework.Core.Repositories.CategoryProperty;
using Smafac.Sales.Order.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Repositories.CategoryProperty
{
    class OrderCategoryPropertySearchRepository : CategoryPropertySearchRepository<OrderContext, OrderCategoryEntity, OrderPropertyEntity, OrderCategoryPropertyEntity>,
                                                  IOrderCategoryPropertySearchRepository
    {
        public OrderCategoryPropertySearchRepository(IOrderContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}
