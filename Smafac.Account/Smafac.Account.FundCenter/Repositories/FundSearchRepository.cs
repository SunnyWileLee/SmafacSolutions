using Smafac.Account.FundCenter.Domain;
using Smafac.Framework.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Account.FundCenter.Repositories
{
    class FundSearchRepository : EntitySearchRepository<FundCenterContext, SubscriberFundEntity>, IFundSearchRepository
    {
        public FundSearchRepository(IFundCenterContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }

        public SubscriberFundEntity First(Guid subscriberId)
        {
            using (var context = ContextProvider.Provide())
            {
                var fund = context.SubscriberFunds.FirstOrDefault(s => s.SubscriberId == subscriberId);
                if (fund == null)
                {
                    fund = CreateFund(subscriberId);
                    context.SubscriberFunds.Add(fund);
                    context.SaveChanges();
                }
                return fund;
            }
        }

        private SubscriberFundEntity CreateFund(Guid subscriberId)
        {
            return new SubscriberFundEntity
            {
                Balance = 0,
                SubscriberId = subscriberId
            };
        }
    }
}
