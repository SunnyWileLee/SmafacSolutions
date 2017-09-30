using Smafac.Account.FundCenter.Models;
using Smafac.Account.FundCenter.Repositories;
using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Account.FundCenter.Domain.Consume
{
    class ConsumeHandler : IConsumeHandler
    {
        private readonly IConsumeThingSearchRepository _consumeThingSearchRepository;
        private readonly IFundSearchRepository _fundRepository;
        private readonly IConsumeAddRepository _consumeAddRepository;
        private readonly IFundUpdateRepository _fundUpdateRepository;

        public ConsumeHandler(IConsumeThingSearchRepository consumeThingSearchRepository,
                                IFundSearchRepository fundRepository,
                                IConsumeAddRepository consumeAddRepository,
                                IFundUpdateRepository fundUpdateRepository)
        {
            _consumeThingSearchRepository = consumeThingSearchRepository;
            _fundRepository = fundRepository;
            _consumeAddRepository = consumeAddRepository;
            _fundUpdateRepository = fundUpdateRepository;
        }

        public bool Consume(ConsumeThingType thingType)
        {
            var thing = _consumeThingSearchRepository.GetByType(thingType);
            var subscriberId = UserContext.Current.SubscriberId;
            var fund = _fundRepository.First(subscriberId);
            var passportId = UserContext.Current.UserId;
            var consume = CreateConsumeEntity(fund, passportId, thing);
            if (_consumeAddRepository.AddEntity(consume))
            {
                return _fundUpdateRepository.MinusBalance(subscriberId, thing.Price);
            }
            return false;
        }

        protected virtual ConsumeEntity CreateConsumeEntity(SubscriberFundEntity fund, Guid passportId, ConsumeThingEntity thing)
        {
            return new ConsumeEntity
            {
                BeforeAmount = fund.Balance,
                AfterAmount = fund.Balance - thing.Price,
                Amount = thing.Price,
                SubscriberId = fund.SubscriberId,
                ConsumeThingId = thing.Id,
                PassportId = passportId,
                Memo = "自动计费"
            };
        }
    }
}
