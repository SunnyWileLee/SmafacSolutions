using Smafac.Crm.Customer.Domain;
using Smafac.Crm.Customer.Models;
using Smafac.Framework.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Repositories
{
    class CustomerSearchRepository : EntitySearchRepository<CustomerContext, CustomerEntity>,
                                        ICustomerSearchRepository
    {
        public CustomerSearchRepository(ICustomerContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}
