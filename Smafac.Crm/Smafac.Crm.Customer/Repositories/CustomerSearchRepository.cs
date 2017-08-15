using Smafac.Crm.Customer.Domain;
using Smafac.Crm.Customer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<CustomerModel> GetCustomerPage(CustomerPageQueryModel query)
        {
            return new List<CustomerModel>();
        }

        public int GetCustomerCount(CustomerPageQueryModel query)
        {
            return 0;
        }
    }
}
