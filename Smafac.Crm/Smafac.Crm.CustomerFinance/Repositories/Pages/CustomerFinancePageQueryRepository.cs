using System.Collections.Generic;
using System.Linq;
using Smafac.Crm.CustomerFinance.Domain;
using Smafac.Crm.CustomerFinance.Models;
using Smafac.Framework.Core.Repositories.Pages;
using Smafac.Crm.CustomerFinance.Repositories.Joiners;
using System;
using System.Data.Entity;

namespace Smafac.Crm.CustomerFinance.Repositories.Pages
{
    class CustomerFinancePageQueryRepository : PageQueryRepository<CustomerFinanceContext, CustomerFinanceEntity, CustomerFinanceModel>
                                                , ICustomerFinancePageQueryRepository
    {
        private readonly ICustomerFinanceJoiner _customerFinanceJoiner;

        public CustomerFinancePageQueryRepository(ICustomerFinanceContextProvider contextProvider,
                                                    ICustomerFinanceJoiner customerFinanceJoiner)
        {
            base.ContextProvider = contextProvider;
            _customerFinanceJoiner = customerFinanceJoiner;
        }

        protected override List<CustomerFinanceModel> SelectModel(IQueryable<CustomerFinanceEntity> query, CustomerFinanceContext context)
        {
            var models = _customerFinanceJoiner.Join(query, context.CustomerFinanceCategories);
            return models.ToList();
        }
    }
}
