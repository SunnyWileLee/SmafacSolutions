using Smafac.Crm.CustomerFinance.Domain.CategoryProperty;
using Smafac.Crm.CustomerFinance.Models;
using Smafac.Crm.CustomerFinance.Repositories;
using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;

namespace Smafac.Crm.CustomerFinance.Domain.Property
{
    class CustomerFinancePropertyProvider : ICustomerFinancePropertyProvider
    {
        private readonly ICustomerFinanceSearchRepository _customerFinanceSearchRepository;
        private readonly ICustomerFinanceCategoryPropertyProvider _customerFinanceCategoryPropertyProvider;

        public CustomerFinancePropertyProvider(ICustomerFinanceSearchRepository customerFinanceSearchRepository,
                                    ICustomerFinanceCategoryPropertyProvider customerFinanceCategoryPropertyProvider
                                    )
        {
            _customerFinanceSearchRepository = customerFinanceSearchRepository;
            _customerFinanceCategoryPropertyProvider = customerFinanceCategoryPropertyProvider;
        }

        public List<CustomerFinancePropertyModel> Provide(Guid customerFinanceId)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var customerFinance = _customerFinanceSearchRepository.GetModel(subscriberId, customerFinanceId);
            return _customerFinanceCategoryPropertyProvider.ProvideAssociations(customerFinance.CategoryId);
        }
    }
}
