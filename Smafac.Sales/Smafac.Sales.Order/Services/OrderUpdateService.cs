using AutoMapper;
using Smafac.Framework.Core.Models;
using Smafac.Sales.Order.Applications;
using Smafac.Sales.Order.Domain;
using Smafac.Sales.Order.Models;
using Smafac.Sales.Order.Repositories;
using Smafac.Sales.Order.Repositories.ChargeValue;
using Smafac.Sales.Order.Repositories.PropertyValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Services
{
    class OrderUpdateService : IOrderUpdateService
    {
        private readonly IOrderUpdateRepository _orderUpdateRepository;
        private readonly IOrderPropertyValueSetRepository _orderPropertyValueSetRepository;
        private readonly IOrderChargeValueUpdateRepository _orderChargeValueUpdateRepository;

        public OrderUpdateService(IOrderUpdateRepository orderUpdateRepository,
                                    IOrderPropertyValueSetRepository orderPropertyValueSetRepository,
                                    IOrderChargeValueUpdateRepository orderChargeValueUpdateRepository)
        {
            _orderUpdateRepository = orderUpdateRepository;
            _orderPropertyValueSetRepository = orderPropertyValueSetRepository;
            _orderChargeValueUpdateRepository = orderChargeValueUpdateRepository;
        }

        public bool UpdateOrder(OrderModel model)
        {
            var order = Mapper.Map<OrderEntity>(model);
            order.SubscriberId = UserContext.Current.SubscriberId;
            var update = _orderUpdateRepository.UpdateEntity(order);

            if (update && model.HasProperties)
            {
                model.Properties.ForEach(property =>
                {
                    property.OrderId = order.Id;
                    property.SubscriberId = order.SubscriberId;
                    var value = Mapper.Map<OrderPropertyValueEntity>(property);
                    update &= _orderPropertyValueSetRepository.SetPropertyValue(value);
                });
            }

            if (update && model.HasCharges)
            {
                model.Charges.ForEach(charge =>
                {
                    charge.SubscriberId = order.SubscriberId;
                    var value = Mapper.Map<OrderChargeValueEntity>(charge);
                    update &= _orderChargeValueUpdateRepository.UpdateEntity(value);
                });
            }
            return update;
        }
    }
}
