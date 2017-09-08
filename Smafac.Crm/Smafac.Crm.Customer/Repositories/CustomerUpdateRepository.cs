using Smafac.Crm.Customer.Domain;
using Smafac.Framework.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Repositories
{
    class CustomerUpdateRepository : EntityUpdateRepository<CustomerContext, CustomerEntity>,
                                    ICustomerUpdateRepository
    {
        public CustomerUpdateRepository(CustomerContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
        protected override void SetValue(CustomerEntity entity, CustomerEntity source)
        {
            entity.Address = source.Address;
            entity.MobileNumber = source.MobileNumber;
            entity.Name = source.Name;
        }
    }
}
