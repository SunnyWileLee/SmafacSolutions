using Smafac.Account.FundCenter.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Account.FundCenter.Domain.Consume
{
    class BalanceChecker : IBalanceChecker
    {
        private readonly IFundSearchRepository _fundRepository;

        public BalanceChecker(IFundSearchRepository fundRepository)
        {
            _fundRepository = fundRepository;
        }

        public bool Check(Guid subscriberId)
        {
            var fund = _fundRepository.First(subscriberId);
            return fund.Balance > 0;
        }
    }
}
