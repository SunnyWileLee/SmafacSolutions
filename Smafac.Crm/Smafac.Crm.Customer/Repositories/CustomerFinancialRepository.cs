using Smafac.Crm.Customer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Repositories
{
    class CustomerFinancialRepository : ICustomerFinancialRepository
    {
        private readonly ICustomerContextProvider _customerContextProvider;

        public CustomerFinancialRepository(ICustomerContextProvider customerContextProvider)
        {
            _customerContextProvider = customerContextProvider;
        }

        public bool AddFinancial(CustomerFinancialEntity financial)
        {
            using (var context = _customerContextProvider.Provide())
            {
                context.CustomerFinancials.Add(financial);
                return context.SaveChanges() > 0;
            }
        }
    }
}
