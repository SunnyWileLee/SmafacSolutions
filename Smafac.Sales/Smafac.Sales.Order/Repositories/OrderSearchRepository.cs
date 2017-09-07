using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Smafac.Sales.Order.Domain;
using Smafac.Framework.Core.Repositories;
using Smafac.Sales.Order.Domain.Pages;

namespace Smafac.Sales.Order.Repositories
{
    class OrderSearchRepository : EntitySearchRepository<OrderContext, OrderEntity>, IOrderSearchRepository
    {
        public OrderSearchRepository(IOrderContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}
