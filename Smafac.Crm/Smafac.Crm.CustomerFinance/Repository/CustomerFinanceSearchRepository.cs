using Smafac.Crm.CustomerFinance.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Smafac.Crm.CustomerFinance.Repository
{
    class CustomerFinanceSearchRepository : ICustomerFinanceSearchRepository
    {
        private readonly ICustomerFinanceContextProvider _orderContextProvider;

        public CustomerFinanceSearchRepository(ICustomerFinanceContextProvider orderContextProvider)
        {
            _orderContextProvider = orderContextProvider;
        }

        public CustomerFinanceEntity GetById(Guid subscriberId, Guid orderId)
        {
            using (var context = _orderContextProvider.Provide())
            {
                var order = context.CustomerFinances.FirstOrDefault(s => s.SubscriberId == subscriberId && s.Id == orderId);
                return order;
            }
        }

        public int GetCustomerFinanceCount(Guid subscriberId, Expression<Func<CustomerFinanceEntity, bool>> predicate)
        {
            using (var context = _orderContextProvider.Provide())
            {
                var count = context.CustomerFinances.Where(s => s.SubscriberId == subscriberId).Count(predicate);
                return count;
            }
        }

        public List<CustomerFinanceEntity> GetCustomerFinancePage(Guid subscriberId, Expression<Func<CustomerFinanceEntity, bool>> predicate, int skip, int take)
        {
            using (var context = _orderContextProvider.Provide())
            {
                var orders = context.CustomerFinances.Where(s => s.SubscriberId == subscriberId)
                                        .Where(predicate).OrderByDescending(s => s.CreateTime)
                                        .Skip(skip).Take(take).ToList();
                return orders;
            }
        }
    }
}
