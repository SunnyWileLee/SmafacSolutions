using Smafac.Crm.Customer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Repositories
{
    class CustomerVisitRepository : ICustomerVisitRepository
    {
        private readonly ICustomerContextProvider _customerContextProvider;

        public CustomerVisitRepository(ICustomerContextProvider customerContextProvider)
        {
            _customerContextProvider = customerContextProvider;
        }

        public bool AddVisit(CustomerVisitEntity visit)
        {
            using (var context = _customerContextProvider.Provide())
            {
                context.CustomerVisits.Add(visit);
                return context.SaveChanges() > 0;
            }
        }
    }
}
