using Smafac.Crm.CustomerFinance.Domain;
using Smafac.Crm.CustomerFinance.Model;
using System;
using System.Linq;

namespace Smafac.Crm.CustomerFinance.Repository
{
    class CustomerFinanceRepository : ICustomerFinanceRepository
    {
        private readonly ICustomerFinanceContextProvider _orderContextProvider;

        public CustomerFinanceRepository(ICustomerFinanceContextProvider orderContextProvider)
        {
            _orderContextProvider = orderContextProvider;
        }

        public bool AddCustomerFinance(CustomerFinanceEntity order)
        {
            using (var context = _orderContextProvider.Provide())
            {
                context.CustomerFinances.Add(order);
                return context.SaveChanges() > 0;
            }
        }

        public bool DeleteCustomerFinance(Guid subscriberId, Guid orderId)
        {
            using (var context = _orderContextProvider.Provide())
            {
                var order = context.CustomerFinances.FirstOrDefault(s => s.SubscriberId == subscriberId && s.Id == orderId);
                if (order == null)
                {
                    return true;
                }
                context.CustomerFinances.Remove(order);
                return context.SaveChanges() > 0;
            }
        }

        public bool UpdateCustomerFinance(CustomerFinanceModel model)
        {
            using (var context = _orderContextProvider.Provide())
            {
                var order = context.CustomerFinances.FirstOrDefault(s => s.SubscriberId == model.SubscriberId && s.Id == model.Id);
                if (order == null)
                {
                    return false;
                }
                order.CustomerId = model.CustomerId;
                order.Memo = model.Memo;
                return context.SaveChanges() > 0;
            }
        }
    }
}
