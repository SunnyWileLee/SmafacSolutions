using Smafac.Account.Subscriber.Applications;
using Smafac.Account.Subscriber.Domain;
using Smafac.Account.Subscriber.Models;
using Smafac.Account.Subscriber.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Account.Subscriber.Services
{
    class SubscriberService : ISubscriberService
    {
        private readonly ISubscriberRepository _subscriberRepository;
        private readonly IPassportSearchRepository _passportSearchRepository;
        private readonly IPassportRepository _passportRepository;

        public SubscriberService(ISubscriberRepository subscriberRepository,
                                IPassportSearchRepository passportSearchRepository,
                                IPassportRepository passportRepository)
        {
            _subscriberRepository = subscriberRepository;
            _passportSearchRepository = passportSearchRepository;
            _passportRepository = passportRepository;
        }
        public bool Register(PassportModel model)
        {
            var passport = _passportSearchRepository.GetPassportByName(model.UserName);
            if (passport != null)
            {
                return false;
            }
            SubscriberEntity subscriber = new SubscriberEntity
            {
                Id = Guid.NewGuid(),
                CreateTime = DateTime.Now,
                Name = model.UserName
            };
            var addSubscriber = _subscriberRepository.AddSubscriber(subscriber);
            if (!addSubscriber)
            {
                return false;
            }
            passport = new PassportEntity
            {
                UserName = model.UserName,
                Password = model.Password,
                SubscriberId = subscriber.Id
            };
            return _passportRepository.AddPassport(passport);
        }
    }
}
