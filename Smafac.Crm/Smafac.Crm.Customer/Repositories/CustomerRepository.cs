using Smafac.Crm.Customer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Repositories
{
    class CustomerRepository : ICustomerRepository
    {
        private readonly ICustomerContextProvider _customerContextProvider;

        public CustomerRepository(ICustomerContextProvider customerContextProvider)
        {
            _customerContextProvider = customerContextProvider;
        }

        public bool AddCustomer(CustomerEntity customer)
        {
            using (var context = _customerContextProvider.Provide())
            {
                context.Customers.Add(customer);
                return context.SaveChanges() > 0;
            }
        }

        public bool DeleteCustomer(Guid SubscriberId, Guid customerId)
        {
            using (var context = _customerContextProvider.Provide())
            {
                var customer = context.Customers.FirstOrDefault(s => s.Id == customerId && s.SubscriberId == SubscriberId);
                context.Customers.Remove(customer);
                return context.SaveChanges() > 0;
            }
        }
    }
}
