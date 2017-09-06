using AutoMapper;
using Smafac.Crm.CustomerFinance.Applications;
using Smafac.Crm.CustomerFinance.Domain;
using Smafac.Crm.CustomerFinance.Domain.Pages;
using Smafac.Crm.CustomerFinance.Models;
using Smafac.Crm.CustomerFinance.Repositories;
using Smafac.Crm.CustomerFinance.Repositories.Pages;
using Smafac.Crm.CustomerFinance.Repositories.Property;
using Smafac.Crm.CustomerFinance.Repositories.PropertyValue;
using Smafac.Framework.Core.Models;
using Smafac.Framework.Core.Repositories.Query;
using Smafac.Framework.Models;
using System;
using System.Collections.Generic;

namespace Smafac.Crm.CustomerFinance.Services
{
    class CustomerFinanceSearchService : ICustomerFinanceSearchService
    {
        private readonly ICustomerFinanceSearchRepository _financeSearchRepository;
        private readonly ICustomerFinancePropertyValueSearchRepository _financePropertyValueSearchRepository;
        private readonly IQueryExpressionCreaterProvider _queryExpressionCreaterProvider;
        private readonly ICustomerFinancePageQueryer _customerFinancePageQueryer;

        public CustomerFinanceSearchService(ICustomerFinanceSearchRepository financeSearchRepository,
                                    ICustomerFinancePropertyValueSearchRepository financePropertyValueSearchRepository,
                                    IQueryExpressionCreaterProvider queryExpressionCreaterProvider,
                                    ICustomerFinancePageQueryer customerFinancePageQueryer
                                    )
        {
            _financeSearchRepository = financeSearchRepository;
            _financePropertyValueSearchRepository = financePropertyValueSearchRepository;
            _queryExpressionCreaterProvider = queryExpressionCreaterProvider;
            _customerFinancePageQueryer = customerFinancePageQueryer;
        }

        public CustomerFinanceModel GetCustomerFinance(Guid financeId)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var finance = _financeSearchRepository.GetById(subscriberId, financeId);
            var properties = _financePropertyValueSearchRepository.GetPropertyValues(subscriberId, financeId);
            finance.Properties = properties;
            return finance;
        }

        public CustomerFinanceDetailModel GetCustomerFinanceDetail(Guid financeId)
        {
            var finance = this.GetCustomerFinance(financeId);
            return new CustomerFinanceDetailModel { CustomerFinance = finance };
        }

        public PageModel<CustomerFinanceModel> GetCustomerFinancePage(CustomerFinancePageQueryModel query)
        {
            return _customerFinancePageQueryer.Query(query);
        }
    }
}
