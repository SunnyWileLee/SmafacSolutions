using AutoMapper;
using Smafac.Framework.Core.Models;
using Smafac.Sales.Order.Applications;
using Smafac.Sales.Order.Domain.Pages;
using Smafac.Sales.Order.Models;
using Smafac.Sales.Order.Repositories;
using Smafac.Sales.Order.Repositories.ChargeValue;
using Smafac.Sales.Order.Repositories.PropertyValue;
using System;

namespace Smafac.Sales.Order.Services
{
    class OrderSearchService : IOrderSearchService
    {
        private readonly IOrderSearchRepository _orderSearchRepository;
        private readonly IOrderChargeValueSearchRepository _orderChargeValueSearchRepository;
        private readonly IOrderPropertyValueSearchRepository _orderPropertyValueSearchRepository;
        private readonly IOrderPageQueryer _orderPageQueryer;

        public OrderSearchService(IOrderSearchRepository orderSearchRepository,
                                    IOrderChargeValueSearchRepository orderChargeValueSearchRepository,
                                    IOrderPropertyValueSearchRepository orderPropertyValueSearchRepository,
                                    IOrderPageQueryer orderPageQueryer
                                    )
        {
            _orderSearchRepository = orderSearchRepository;
            _orderPropertyValueSearchRepository = orderPropertyValueSearchRepository;
            _orderChargeValueSearchRepository = orderChargeValueSearchRepository;
            _orderPageQueryer = orderPageQueryer;
        }

        public OrderModel GetOrder(Guid orderId)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var order = _orderSearchRepository.GetEntity(subscriberId, orderId);
            var properties = _orderPropertyValueSearchRepository.GetPropertyValues(subscriberId, orderId);
            var charges = _orderChargeValueSearchRepository.GetChargeValues(subscriberId, orderId);
            var model = Mapper.Map<OrderModel>(order);
            model.Properties = properties;
            model.Charges = charges;
            return model;
        }

        public OrderDetailModel GetOrderDetail(Guid orderId)
        {
            var order = this.GetOrder(orderId);
            return new OrderDetailModel { Order = order };
        }

        public OrderPageModel GetOrderPage(OrderPageQueryModel query)
        {
            return _orderPageQueryer.QueryOrderPage(query);
        }
    }
}
