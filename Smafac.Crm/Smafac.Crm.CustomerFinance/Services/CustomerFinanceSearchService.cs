using AutoMapper;
using Smafac.Crm.CustomerFinance.Applications;
using Smafac.Crm.CustomerFinance.Domain;
using Smafac.Crm.CustomerFinance.Models;
using Smafac.Crm.CustomerFinance.Repository;
using Smafac.Crm.CustomerFinance.Repository.Property;
using Smafac.Framework.Core.Models;
using Smafac.Framework.Core.Repositories.Query;
using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Smafac.Crm.CustomerFinance.Services
{
    class CustomerFinanceSearchService : ICustomerFinanceSearchService
    {
        private readonly ICustomerFinanceSearchRepository _financeSearchRepository;
        private readonly ICustomerFinancePropertyValueRepository _financePropertyValueRepository;
        private readonly IQueryExpressionCreaterProvider _queryExpressionCreaterProvider;

        public CustomerFinanceSearchService(ICustomerFinanceSearchRepository financeSearchRepository,
                                    ICustomerFinancePropertyValueRepository financePropertyValueRepository,
                                    IQueryExpressionCreaterProvider queryExpressionCreaterProvider
                                    )
        {
            _financeSearchRepository = financeSearchRepository;
            _financePropertyValueRepository = financePropertyValueRepository;
            _queryExpressionCreaterProvider = queryExpressionCreaterProvider;
        }

        public CustomerFinanceModel GetCustomerFinance(Guid financeId)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var finance = _financeSearchRepository.GetById(subscriberId, financeId);
            var properties = _financePropertyValueRepository.GetPropertyValues(subscriberId, financeId);
            finance.Properties = properties;
            return finance;
        }

        public CustomerFinanceDetailModel GetCustomerFinanceDetail(Guid financeId)
        {
            var finance = this.GetCustomerFinance(financeId);
            return new CustomerFinanceDetailModel { CustomerFinance = finance };
        }

        public PageModel<CustomerFinanceModel> GetCustomerFinancePage(CustomerFinancePageQueryModel model)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var predicate = _queryExpressionCreaterProvider.Provide<CustomerFinanceEntity>().Create(model);
            var finances = _financeSearchRepository.GetCustomerFinancePage(subscriberId, predicate, model.Skip, model.PageSize);
            var count = _financeSearchRepository.GetCustomerFinanceCount(subscriberId, predicate);
            return new PageModel<CustomerFinanceModel>(model)
            {
                PageData = Mapper.Map<List<CustomerFinanceModel>>(finances),
                TotalCount = count
            };
        }
    }
}
