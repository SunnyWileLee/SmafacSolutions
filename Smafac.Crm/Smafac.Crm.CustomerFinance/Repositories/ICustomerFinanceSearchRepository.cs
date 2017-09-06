using Smafac.Crm.CustomerFinance.Domain;
using Smafac.Crm.CustomerFinance.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Smafac.Crm.CustomerFinance.Repositories
{
    interface ICustomerFinanceSearchRepository
    {
        CustomerFinanceModel GetById(Guid subscriberId, Guid financeId);
    }
}
