using Smafac.Crm.Customer.Domain;
using Smafac.Crm.Customer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Repositories
{
    class CustomerVisitSearchRepository : ICustomerVisitSearchRepository
    {

        private readonly ICustomerContextProvider _customerContextProvider;

        public CustomerVisitSearchRepository(ICustomerContextProvider customerContextProvider)
        {
            _customerContextProvider = customerContextProvider;
        }

        public List<CustomerVisitModel> GetVisits(Expression<Func<CustomerVisitEntity, bool>> predicate, int skip, int take)
        {
            using (var context = _customerContextProvider.Provide())
            {
                var visits = context.CustomerVisits
                                    .Where(predicate)
                                    .OrderByDescending(s => s.CreateTime)
                                    .Skip(skip).Take(take)
                                    .Select(s => new CustomerVisitModel
                                    {
                                        SubscriberId = s.SubscriberId,
                                        Content = s.Content,
                                        Cost = s.Cost,
                                        CreateTime = s.CreateTime,
                                        CustomerId = s.CustomerId,
                                        Id = s.Id,
                                        InvokerId = s.InvokerId,
                                        Memo = s.Memo,
                                        VisitTime = s.VisitTime
                                    }).ToList();
                return visits;
            }
        }

        public int GetVisitCount(Expression<Func<CustomerVisitEntity, bool>> predicate)
        {
            using (var context = _customerContextProvider.Provide())
            {
                var visits = context.CustomerVisits.Count(predicate);
                return visits;
            }
        }
    }
}
