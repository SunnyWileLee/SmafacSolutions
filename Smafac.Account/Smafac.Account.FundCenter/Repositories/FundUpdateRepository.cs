using Smafac.Account.FundCenter.Domain;
using Smafac.Framework.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Account.FundCenter.Repositories
{
    class FundUpdateRepository : EntityUpdateRepository<FundCenterContext, SubscriberFundEntity>, IFundUpdateRepository
    {
        public FundUpdateRepository(IFundCenterContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }

        public bool AddBalance(Guid subscriberId, decimal amount)
        {
            using (var context = ContextProvider.Provide())
            {
                var fund = context.SubscriberFunds.First(s => s.SubscriberId == subscriberId);
                ChangeBalance(fund, true, amount);
                return context.SaveChanges() > 0;
            }
        }

        public bool MinusBalance(Guid subscriberId, decimal amount)
        {
            using (var context = ContextProvider.Provide())
            {
                var fund = context.SubscriberFunds.First(s => s.SubscriberId == subscriberId);
                ChangeBalance(fund, false, amount);
                return context.SaveChanges() > 0;
            }
        }

        private void ChangeBalance(SubscriberFundEntity fund, bool isAdd, decimal amount)
        {
            if (isAdd)
            {
                fund.Balance += amount;
            }
            else
            {
                fund.Balance -= amount;
            }
        }

        protected override void SetValue(SubscriberFundEntity entity, SubscriberFundEntity source)
        {

        }
    }
}
