using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Framework.Models;
using Smafac.Framework.Core.Models;
using Smafac.Sales.Order.Repositories;
using Smafac.Sales.Order.Models;
using Smafac.Sales.Order.Domain.CategoryProperty;

namespace Smafac.Sales.Order.Domain.Property
{
    class OrderPropertyProvider : IOrderPropertyProvider
    {
        private readonly IOrderSearchRepository _orderSearchRepository;
        private readonly IOrderCategoryPropertyProvider _orderCategoryPropertyProvider;

        public OrderPropertyProvider(IOrderSearchRepository OrderSearchRepository,
                                    IOrderCategoryPropertyProvider OrderCategoryPropertyProvider
                                    )
        {
            _orderSearchRepository = OrderSearchRepository;
            _orderCategoryPropertyProvider = OrderCategoryPropertyProvider;
        }

        public List<OrderPropertyModel> Provide(Guid orderId)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var order = _orderSearchRepository.GetById(subscriberId, orderId);
            return _orderCategoryPropertyProvider.ProvideAssociations(order.CategoryId);
        }
    }
}
