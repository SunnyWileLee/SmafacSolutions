using Smafac.Crm.Customer.Domain;
using Smafac.Crm.Customer.Models;
using Smafac.Framework.Core.Domain;
using Smafac.Framework.Core.Repositories.Pages;
using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Repositories.Pages
{
    interface ICustomerPageQueryRepository : IPageQueryRepository<CustomerEntity, CustomerModel>
    {

    }
}
