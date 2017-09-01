using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Sales.Order.Models;
using Smafac.Framework.Core.Models;
using Smafac.Sales.Order.Repositories;
using Smafac.Sales.Order.Domain.CategoryProperty;

namespace Smafac.Sales.Order.Domain.Charge
{
    class OrderChargeProvider : IOrderChargeProvider
    {

        private readonly IOrderSearchRepository _orderSearchRepository;
        private readonly IOrderCategoryChargeProvider _orderCategoryChargeProvider;

        public OrderChargeProvider(IOrderSearchRepository orderSearchRepository,
                                    IOrderCategoryChargeProvider orderCategoryChargeProvider
                                    )
        {
            _orderSearchRepository = orderSearchRepository;
            _orderCategoryChargeProvider = orderCategoryChargeProvider;
        }

        public List<OrderChargeModel> Provide(Guid orderId)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var order = _orderSearchRepository.GetById(subscriberId, orderId);
            return _orderCategoryChargeProvider.ProvideAssociations(order.CategoryId);
        }
    }
}
