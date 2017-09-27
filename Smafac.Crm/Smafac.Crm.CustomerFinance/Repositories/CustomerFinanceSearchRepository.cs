using Smafac.Crm.CustomerFinance.Domain;
using Smafac.Crm.CustomerFinance.Models;
using Smafac.Crm.CustomerFinance.Repositories.Joiners;
using Smafac.Framework.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Smafac.Crm.CustomerFinance.Repositories
{
    class CustomerFinanceSearchRepository : EntitySearchRepository<CustomerFinanceContext, CustomerFinanceEntity>,
                                            ICustomerFinanceSearchRepository
    {
        private readonly ICustomerFinanceJoiner _customerFinanceJoiner;

        public CustomerFinanceSearchRepository(ICustomerFinanceContextProvider contextProvider,
                                                ICustomerFinanceJoiner customerFinanceJoiner)
        {
            base.ContextProvider = contextProvider;
            _customerFinanceJoiner = customerFinanceJoiner;
        }

        public CustomerFinanceModel GetModel(Guid subscriberId, Guid financeId)
        {
            using (var context = ContextProvider.Provide())
            {
                var finances = context.CustomerFinances.Where(s => s.SubscriberId == subscriberId && s.Id == financeId);
                var finance = _customerFinanceJoiner.Join(finances, context.CustomerFinanceCategories).FirstOrDefault();
                return finance;
            }
        }

        public List<CustomerFinanceModel> GetModels(Guid subscriberId, Expression<Func<CustomerFinanceEntity, bool>> predicate)
        {
            using (var context = ContextProvider.Provide())
            {
                var finances = context.CustomerFinances.Where(s => s.SubscriberId == subscriberId).Where(predicate);
                var models = _customerFinanceJoiner.Join(finances, context.CustomerFinanceCategories).ToList();
                return models;
            }
        }
    }
}
