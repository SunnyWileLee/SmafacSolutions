using Smafac.Crm.Customer.Domain;
using Smafac.Crm.Customer.Models;
using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Smafac.Crm.Customer.Repositories
{
    interface ICustomerSearchRepository
    {
        CustomerEntity GetById(Guid SubscriberId, Guid customerId);
        List<CustomerEntity> GetCustomerPage(Guid subscriberId, Expression<Func<CustomerEntity, bool>> predicate, int skip, int take);
        List<CustomerEntity> GetCustomers(Guid subscriberId, Expression<Func<CustomerEntity, bool>> predicate);
        int GetCustomerCount(Guid subscriberId, Expression<Func<CustomerEntity, bool>> predicate);
    }
}
