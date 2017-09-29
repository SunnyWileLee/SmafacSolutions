using Smafac.Crm.Customer.Domain;
using Smafac.Crm.Customer.Models;
using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Smafac.Framework.Core.Repositories;

namespace Smafac.Crm.Customer.Repositories
{
    interface ICustomerSearchRepository : IEntitySearchRepository<CustomerEntity>
    {

    }
}
