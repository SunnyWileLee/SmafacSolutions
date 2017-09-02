using AutoMapper;
using Newtonsoft.Json;
using Smafac.Crm.CustomerFinance.Applications;
using Smafac.Crm.CustomerFinance.Domain;
using Smafac.Crm.CustomerFinance.Model;
using Smafac.Crm.CustomerFinance.Repository;
using Smafac.Crm.CustomerFinance.Repository.Property;
using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Smafac.Crm.CustomerFinance.Services
{
    class CustomerFinanceService : ICustomerFinanceService
    {
        private readonly ICustomerFinanceRepository _orderRepository;
        private readonly ICustomerFinancePropertyValueRepository _orderPropertyValueRepository;
        private readonly ICustomerFinancePropertySearchRepository _orderPropertySearchRepository;

        public CustomerFinanceService(ICustomerFinanceRepository orderRepository,
                            ICustomerFinancePropertyValueRepository orderPropertyValueRepository,
                            ICustomerFinancePropertySearchRepository orderPropertySearchRepository)
        {
            _orderRepository = orderRepository;
            _orderPropertyValueRepository = orderPropertyValueRepository;
            _orderPropertySearchRepository = orderPropertySearchRepository;
        }

        public bool AddCustomerFinance(CustomerFinanceModel model)
        {
            var order = Mapper.Map<CustomerFinanceEntity>(model);
            order.SubscriberId = UserContext.Current.SubscriberId;
            if (_orderRepository.AddCustomerFinance(order))
            {
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

        private bool AddPropertyValues(CustomerFinanceEntity order, IEnumerable<CustomerFinancePropertyValueModel> values)
        {
            var properties = Mapper.Map<List<CustomerFinancePropertyValueEntity>>(values);
            properties.ForEach(property =>
            {
                property.CustomerFinanceId = order.Id;
                property.SubscriberId = order.SubscriberId;
            });
            return _orderPropertyValueRepository.AddPropertyValues(order.Id, properties);
        }

        public CustomerFinanceModel CreateEmptyCustomerFinance()
        {
            var properties = _orderPropertySearchRepository.GetEntities(UserContext.Current.SubscriberId, s => true);
            var propertyValues = properties.Select(s => s.CreateEmptyValue()).ToList();
            var order = new CustomerFinanceModel
            {
                Properties = Mapper.Map<List<CustomerFinancePropertyValueModel>>(propertyValues)
            };
            return order;
        }

        public bool DeleteCustomerFinance(Guid orderId)
        {
            return _orderRepository.DeleteCustomerFinance(UserContext.Current.SubscriberId, orderId);
        }

        public bool UpdateCustomerFinance(CustomerFinanceModel model)
        {
            return _orderRepository.UpdateCustomerFinance(model);
        }
    }
}
