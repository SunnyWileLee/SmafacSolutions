using Smafac.Crm.Customer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Repositories
{
    class CustomerReceiveRepository : ICustomerReceiveRepository
    {
        private readonly ICustomerContextProvider _customerContextProvider;

        public CustomerReceiveRepository(ICustomerContextProvider customerContextProvider)
        {
            _customerContextProvider = customerContextProvider;
        }

        public bool AddReceive(CustomerReceiveEntity Receive)
        {
            using (var context = _customerContextProvider.Provide())
            {
                context.CustomerReceives.Add(Receive);
                return context.SaveChanges() > 0;
            }
        }
    }
}
