using Smafac.Crm.Customer.Applications;
using Smafac.Crm.Customer.Models;
using Smafac.Crm.Customer.Repositories;
using Smafac.Framework.Core.Models;
using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Services
{
    class CustomerFinancialSearchService : ICustomerFinancialSearchService
    {
        private readonly ICustomerFinancialSearchRepository _customerFinancialSearchRepository;

        public CustomerFinancialSearchService(ICustomerFinancialSearchRepository customerFinancialSearchRepository)
        {
            _customerFinancialSearchRepository = customerFinancialSearchRepository;
        }

        public PageModel<CustomerFinancialModel> GetFinancialPage(CustomerFinancialPageQueryModel query)
        {
            query.SubscriberId = UserContext.Current.SubscriberId;
            var financials = _customerFinancialSearchRepository.GetFinancials(query);
            var count = _customerFinancialSearchRepository.GetFinancialCount(query);
            return new PageModel<CustomerFinancialModel>
            {
                PageData = financials,
                PageSize = query.PageSize,
                PageIndex = query.PageIndex,
                TotalCount = count
            };
        }
    }
}
