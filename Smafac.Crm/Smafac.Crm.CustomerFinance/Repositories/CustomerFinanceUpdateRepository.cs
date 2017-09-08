using Smafac.Crm.CustomerFinance.Domain;
using Smafac.Framework.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.CustomerFinance.Repositories
{
    class CustomerFinanceUpdateRepository : EntityUpdateRepository<CustomerFinanceContext, CustomerFinanceEntity>,
                                            ICustomerFinanceUpdateRepository
    {
        public CustomerFinanceUpdateRepository(CustomerFinanceContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }

        protected override void SetValue(CustomerFinanceEntity entity, CustomerFinanceEntity source)
        {
            entity.Amount = source.Amount;
            entity.Memo = source.Memo;
        }
    }
}
