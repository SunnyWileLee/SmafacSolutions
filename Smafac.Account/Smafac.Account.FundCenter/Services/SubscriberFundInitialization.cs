using Smafac.Account.FundCenter.Domain;
using Smafac.Account.FundCenter.Repositories;
using Smafac.Framework.Core.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Account.FundCenter.Services
{
    class SubscriberFundInitialization : IDataInitialization
    {
        private readonly IFundAddRepository _fundAddRepository;

        public SubscriberFundInitialization(IFundAddRepository fundAddRepository)
        {
            _fundAddRepository = fundAddRepository;
        }

        public void Init(Guid subscriberId)
        {
            var fund = CreateFund(subscriberId);
            _fundAddRepository.AddEntity(fund);
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
