using Smafac.Sales.Order.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Sales.Order.Models;
using Smafac.Sales.Order.Repositories;
using Smafac.Framework.Core.Models;
using AutoMapper;
using Smafac.Sales.Order.Domain;
using Newtonsoft.Json;
using Smafac.Sales.Order.Repositories.Property;
using Smafac.Sales.Order.Repositories.Charge;

namespace Smafac.Sales.Order.Services
{
    class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderChargeValueRepository _orderChargeValueRepository;
        private readonly IOrderPropertyValueRepository _orderPropertyValueRepository;
        private readonly IOrderChargeRepository _orderChargeRepository;
        private readonly IOrderPropertySearchRepository _orderPropertySearchRepository;

        public OrderService(IOrderRepository orderRepository,
                            IOrderChargeValueRepository orderChargeValueRepository,
                            IOrderPropertyValueRepository orderPropertyValueRepository,
                            IOrderChargeRepository orderChargeRepository,
                            IOrderPropertySearchRepository orderPropertySearchRepository)
        {
            _orderRepository = orderRepository;
            _orderChargeValueRepository = orderChargeValueRepository;
            _orderPropertyValueRepository = orderPropertyValueRepository;
            _orderChargeRepository = orderChargeRepository;
            _orderPropertySearchRepository = orderPropertySearchRepository;
        }

        public bool AddOrder(OrderModel model)
        {
            var order = Mapper.Map<OrderEntity>(model);
            if (_orderRepository.AddOrder(order))
            {
                if (!_orderChargeValueRepository.AddChargeValues(order.Id, Mapper.Map<List<OrderChargeValueEntity>>(model.Charges)))
                {
                    var charges = JsonConvert.SerializeObject(model.Charges);
                }
                if (!_orderPropertyValueRepository.AddPropertyValues(order.Id, Mapper.Map<List<OrderPropertyValueEntity>>(model.Properties)))
                {
                    var charges = JsonConvert.SerializeObject(model.Properties);
                }
                return true;
            }
            return false;
        }

        public OrderModel CreateEmptyOrder()
        {
            var charges = _orderChargeRepository.GetCharges(UserContext.Current.SubscriberId);
            var chargeValues = charges.Select(s => s.CreateEmptyValue()).ToList();
            var properties = _orderPropertySearchRepository.GetEntities(UserContext.Current.SubscriberId, s => true);
            var propertyValues = properties.Select(s => s.CreateEmptyValue()).ToList();
            var order = new OrderModel
            {
                Charges = Mapper.Map<List<OrderChargeValueModel>>(chargeValues),
                Properties = Mapper.Map<List<OrderPropertyValueModel>>(propertyValues)
            };
            return order;
        }

        public bool DeleteOrder(Guid orderId)
        {
            return _orderRepository.DeleteOrder(UserContext.Current.SubscriberId, orderId);
        }

        public bool UpdateOrder(OrderModel model)
        {
            return _orderRepository.UpdateOrder(model);
        }
    }
}
