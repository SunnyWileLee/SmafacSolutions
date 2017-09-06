using Smafac.Framework.Core.Repositories.Pages;
using Smafac.Sales.Order.Domain;
using Smafac.Sales.Order.Models;
using Smafac.Sales.Order.Repositories.Joiners;
using System.Collections.Generic;
using System.Linq;

namespace Smafac.Sales.Order.Repositories.Pages
{
    class OrderPageQueryRepository : PageQueryRepository<OrderContext, OrderEntity, OrderModel>
                                                , IOrderPageQueryRepository
    {
        private readonly IOrderJoiner _orderJoiner;

        public OrderPageQueryRepository(IOrderContextProvider contextProvider,
                                        IOrderJoiner orderJoiner)
        {
            base.ContextProvider = contextProvider;
            _orderJoiner = orderJoiner;
        }

        protected override List<OrderModel> SelectModel(IQueryable<OrderEntity> query, OrderContext context)
        {
            var models = _orderJoiner.Join(query, context.OrderCategories);
            return models.ToList();
        }
    }
}
