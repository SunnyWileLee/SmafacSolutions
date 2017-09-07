using Smafac.Crm.CustomerFinance.Domain;
using Smafac.Crm.CustomerFinance.Models;
using Smafac.Framework.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Smafac.Crm.CustomerFinance.Repositories
{
    interface ICustomerFinanceSearchRepository : IEntitySearchRepository<CustomerFinanceEntity>
    {
        CustomerFinanceModel GetModel(Guid subscriberId, Guid financeId);
    }
}
