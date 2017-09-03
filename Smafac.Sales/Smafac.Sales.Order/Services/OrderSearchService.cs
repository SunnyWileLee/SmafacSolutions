using Smafac.Sales.Order.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Framework.Models;
using Smafac.Sales.Order.Models;
using Smafac.Sales.Order.Repositories;
using Smafac.Framework.Core.Models;
using AutoMapper;
using Smafac.Sales.Order.Domain;
using Smafac.Sales.Order.Repositories.Charge;
using Smafac.Sales.Order.Repositories.Property;
using Smafac.Framework.Core.Repositories.Query;

namespace Smafac.Sales.Order.Services
{
    class OrderSearchService : IOrderSearchService
    {
        private readonly IOrderSearchRepository _orderSearchRepository;
        private readonly IOrderChargeValueRepository _orderChargeValueRepository;
        private readonly IOrderPropertyValueRepository _orderPropertyValueRepository;
        private readonly IQueryExpressionCreaterProvider _queryExpressionCreaterProvider;

        public OrderSearchService(IOrderSearchRepository orderSearchRepository,
                                    IOrderChargeValueRepository orderChargeValueRepository,
                                    IOrderPropertyValueRepository orderPropertyValueRepository,
                                    IQueryExpressionCreaterProvider queryExpressionCreaterProvider
                                    )
        {
            _orderSearchRepository = orderSearchRepository;
            _orderChargeValueRepository = orderChargeValueRepository;
            _orderPropertyValueRepository = orderPropertyValueRepository;
            _queryExpressionCreaterProvider = queryExpressionCreaterProvider;
        }

        public OrderModel GetOrder(Guid orderId)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var order = _orderSearchRepository.GetById(subscriberId, orderId);
            var properties = _orderPropertyValueRepository.GetPropertyValues(subscriberId, orderId);
            var charges = _orderChargeValueRepository.GetChargeValues(subscriberId, orderId);
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

        public PageModel<OrderModel> GetOrderPage(OrderPageQueryModel model)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var predicate = _queryExpressionCreaterProvider.Provide<OrderEntity>().Create(model);
            var orders = _orderSearchRepository.GetOrderPage(subscriberId, predicate, model.Skip, model.PageSize);
            var count = _orderSearchRepository.GetOrderCount(subscriberId, predicate);
            return new PageModel<OrderModel>(model)
            {
                PageData = Mapper.Map<List<OrderModel>>(orders),
                TotalCount = count
            };
        }
    }
}
