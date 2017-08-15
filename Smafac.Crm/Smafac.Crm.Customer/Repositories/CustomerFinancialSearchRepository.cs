using Smafac.Crm.Customer.Domain;
using Smafac.Crm.Customer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Repositories
{
    class CustomerFinancialSearchRepository : ICustomerFinancialSearchRepository
    {

        private readonly ICustomerContextProvider _customerContextProvider;

        public CustomerFinancialSearchRepository(ICustomerContextProvider customerContextProvider)
        {
            _customerContextProvider = customerContextProvider;
        }

        public List<CustomerFinancialModel> GetFinancials(CustomerFinancialPageQueryModel query)
        {
            var predicate = query.CreatePredicate<CustomerFinancialEntity>();
            using (var context = _customerContextProvider.Provide())
            {
                var financials = context.CustomerFinancials.Where(predicate)
                                           .OrderByDescending(s => s.CreateTime)
                                           .Skip(query.Skip)
                                           .Take(query.PageSize)
                                           .Select(s => new CustomerFinancialModel
                                           {
                                               SubscriberId = s.SubscriberId,
                                               StatusId = s.StatusId,
                                               Amount = s.Amount,
                                               CreateTime = s.CreateTime,
                                               CustomerId = s.CustomerId,
                                               Evidence = s.Evidence,
                                               Id = s.Id,
                                               Memo = s.Memo,
                                               PayTime = s.PayTime,
                                               PayTypeId = s.PayTypeId,
                                               TypeId = s.TypeId
                                           })
                                           .ToList();
                return financials;
            }
        }

        public int GetFinancialCount(CustomerFinancialPageQueryModel query)
        {
            var predicate = query.CreatePredicate<CustomerFinancialEntity>();
            using (var context = _customerContextProvider.Provide())
            {
                return context.CustomerFinancials.Count(predicate);
            }
        }
    }
}
