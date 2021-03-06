﻿using Smafac.Crm.CustomerFinance.Domain;
using Smafac.Framework.Core.Repositories.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.CustomerFinance.Repositories.Property
{
    class CustomerFinancePropertyAddRepository : PropertyAddRepository<CustomerFinanceContext, CustomerFinancePropertyEntity>, ICustomerFinancePropertyAddRepository
    {
        public CustomerFinancePropertyAddRepository(ICustomerFinanceContextProvider contextProvider)
        {
            base.ContextProvider  = contextProvider;
        }
    }
}
