using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Framework.Core.Models;
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

        public OrderPropertyProvider(IOrderSearchRepository orderSearchRepository,
                                    IOrderCategoryPropertyProvider orderCategoryPropertyProvider
                                    )
        {
            _orderSearchRepository = orderSearchRepository;
            _orderCategoryPropertyProvider = orderCategoryPropertyProvider;
        }

        public List<OrderPropertyModel> Provide(Guid orderId)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var order = _orderSearchRepository.GetEntity(subscriberId, orderId);
            return _orderCategoryPropertyProvider.ProvideAssociations(order.CategoryId);
        }
    }
}
