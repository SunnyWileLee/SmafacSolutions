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
    class CustomerSearchRepository : ICustomerSearchRepository
    {
        private readonly ICustomerContextProvider _customerContextProvider;

        public CustomerSearchRepository(ICustomerContextProvider customerContextProvider)
        {
            _customerContextProvider = customerContextProvider;
        }
        public CustomerEntity GetById(Guid SubscriberId, Guid customerId)
        {
            using (var context = _customerContextProvider.Provide())
            {
                return context.Customers.FirstOrDefault(s => s.SubscriberId == SubscriberId && s.Id == customerId);
            }
        }

        public List<CustomerEntity> GetCustomerPage(Guid subscriberId, Expression<Func<CustomerEntity, bool>> predicate, int skip, int take)
        {
            using (var context = _customerContextProvider.Provide())
            {
                var customers = context.Customers.Where(s => s.SubscriberId == subscriberId).Where(predicate)
                                .OrderByDescending(s => s.CreateTime)
                                .Skip(skip).Take(take).ToList();
                return customers;
            }
        }

        public int GetCustomerCount(Guid subscriberId, Expression<Func<CustomerEntity, bool>> predicate)
        {
            using (var context = _customerContextProvider.Provide())
            {
                var count = context.Customers.Where(s => s.SubscriberId == subscriberId).Count(predicate);
                return count;
            }
        }

        public List<CustomerEntity> GetCustomers(Guid subscriberId, Expression<Func<CustomerEntity, bool>> predicate)
        {
            using (var context = _customerContextProvider.Provide())
            {
                var customers = context.Customers.Where(s => s.SubscriberId == subscriberId).Where(predicate)
                                                .ToList();
                return customers;
            }
        }
    }
}
