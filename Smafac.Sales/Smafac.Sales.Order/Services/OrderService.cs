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
using Smafac.Sales.Order.Repositories.PropertyValue;
using Smafac.Sales.Order.Repositories.ChargeValue;

namespace Smafac.Sales.Order.Services
{
    class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderChargeValueRepository _orderChargeValueRepository;
        private readonly IOrderPropertyValueSetRepository _orderPropertyValueSetRepository;
        private readonly IOrderChargeSearchRepository _orderChargeSearchRepository;
        private readonly IOrderPropertySearchRepository _orderPropertySearchRepository;

        public IOrderUpdateService UpdateService { get; set; }

        public OrderService(IOrderRepository orderRepository,
                            IOrderUpdateService updateService,
                            IOrderChargeValueRepository orderChargeValueRepository,
                            IOrderPropertyValueSetRepository orderPropertyValueSetRepository,
                            IOrderChargeSearchRepository orderChargeSearchRepository,
                            IOrderPropertySearchRepository orderPropertySearchRepository)
        {
            _orderRepository = orderRepository;
            _orderChargeValueRepository = orderChargeValueRepository;
            _orderPropertyValueSetRepository = orderPropertyValueSetRepository;
            _orderChargeSearchRepository = orderChargeSearchRepository;
            _orderPropertySearchRepository = orderPropertySearchRepository;
            UpdateService = updateService;
        }

        public bool AddOrder(OrderModel model)
        {
            var order = Mapper.Map<OrderEntity>(model);
            order.SubscriberId = UserContext.Current.SubscriberId;
            if (_orderRepository.AddOrder(order))
            {
                if (model.HasCharges)
                {
                    if (!AddChargeValues(order, model.Charges))
                    {
                        var charges = JsonConvert.SerializeObject(model.Charges);
                    }
                }
                if (model.HasProperties)
                {
                    if (!AddPropertyValues(order, model.Properties))
                    {
                        var properties = JsonConvert.SerializeObject(model.Properties);
                    }
                }
                return true;
            }
            return false;
        }

        private bool AddChargeValues(OrderEntity order, IEnumerable<OrderChargeValueModel> values)
        {
            var charges = Mapper.Map<List<OrderChargeValueEntity>>(values);
            charges.ForEach(charge =>
            {
                charge.OrderId = order.Id;
                charge.SubscriberId = order.SubscriberId;
            });
            return _orderChargeValueRepository.AddChargeValues(order.Id, charges);
        }

        private bool AddPropertyValues(OrderEntity order, IEnumerable<OrderPropertyValueModel> values)
        {
            var properties = Mapper.Map<List<OrderPropertyValueEntity>>(values);
            properties.ForEach(property =>
            {
                property.OrderId = order.Id;
                property.SubscriberId = order.SubscriberId;
            });
            return _orderPropertyValueSetRepository.AddPropertyValues(order.Id, properties);
        }

        public OrderModel CreateEmptyOrder()
        {
            var charges = _orderChargeSearchRepository.GetEntities(UserContext.Current.SubscriberId, s => true);
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
    }
}
