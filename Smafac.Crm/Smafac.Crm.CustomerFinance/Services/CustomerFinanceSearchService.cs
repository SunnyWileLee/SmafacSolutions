using AutoMapper;
using Smafac.Crm.CustomerFinance.Applications;
using Smafac.Crm.CustomerFinance.Domain;
using Smafac.Crm.CustomerFinance.Model;
using Smafac.Crm.CustomerFinance.Repository;
using Smafac.Crm.CustomerFinance.Repository.Property;
using Smafac.Framework.Core.Models;
using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Smafac.Crm.CustomerFinance.Services
{
    class CustomerFinanceSearchService : ICustomerFinanceSearchService
    {
        private readonly ICustomerFinanceSearchRepository _orderSearchRepository;
        private readonly ICustomerFinancePropertyValueRepository _orderPropertyValueRepository;

        public CustomerFinanceSearchService(ICustomerFinanceSearchRepository orderSearchRepository,
                                    ICustomerFinancePropertyValueRepository orderPropertyValueRepository
                                    )
        {
            _orderSearchRepository = orderSearchRepository;
            _orderPropertyValueRepository = orderPropertyValueRepository;
        }

        public CustomerFinanceModel GetCustomerFinance(Guid orderId)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var order = _orderSearchRepository.GetById(subscriberId, orderId);
            var properties = _orderPropertyValueRepository.GetPropertyValues(subscriberId, orderId);
            var model = Mapper.Map<CustomerFinanceModel>(order);
            model.Properties = properties;
            return model;
        }

        public CustomerFinanceDetailModel GetCustomerFinanceDetail(Guid orderId)
        {
            var order = this.GetCustomerFinance(orderId);
            return new CustomerFinanceDetailModel { CustomerFinance = order };
        }

        public PageModel<CustomerFinanceModel> GetCustomerFinancePage(CustomerFinancePageQueryModel model)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var predicate = model.CreatePredicate<CustomerFinanceEntity>();
            var orders = _orderSearchRepository.GetCustomerFinancePage(subscriberId, predicate, model.Skip, model.PageSize);
            var count = _orderSearchRepository.GetCustomerFinanceCount(subscriberId, predicate);
            return new PageModel<CustomerFinanceModel>(model)
            {
                PageData = Mapper.Map<List<CustomerFinanceModel>>(orders),
                TotalCount = count
            };
        }
    }
}
