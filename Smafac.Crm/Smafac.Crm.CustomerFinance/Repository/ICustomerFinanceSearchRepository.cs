using Smafac.Crm.CustomerFinance.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Smafac.Crm.CustomerFinance.Repository
{
    interface ICustomerFinanceSearchRepository
    {
        CustomerFinanceEntity GetById(Guid subscriberId, Guid orderId);
        List<CustomerFinanceEntity> GetCustomerFinancePage(Guid subscriberId, Expression<Func<CustomerFinanceEntity, bool>> predicate, int skip, int take);
        int GetCustomerFinanceCount(Guid subscriberId, Expression<Func<CustomerFinanceEntity, bool>> predicate);
    }
}
