﻿using Smafac.Account.Subscriber.Models;
using Smafac.Account.Subscriber.Repositories;
using Smafac.Infrustructure.Common;
using System;

namespace Smafac.Account.Subscriber.Domain
{
    class SubscriberRegister : ISubscriberRegister
    {
        private readonly ISubscriberRepository _subscriberRepository;
        private readonly IPassportSearchRepository _passportSearchRepository;
        private readonly IPassportRepository _passportRepository;
        private readonly IMd5Encrypter _encrypt;


        public SubscriberRegister(ISubscriberRepository subscriberRepository,
                                IPassportSearchRepository passportSearchRepository,
                                IPassportRepository passportRepository,
                                IMd5Encrypter encrypt)
        {
            _subscriberRepository = subscriberRepository;
            _passportSearchRepository = passportSearchRepository;
            _passportRepository = passportRepository;
            _encrypt = encrypt;

        }

        public Guid Register(PassportModel model)
        {
            var passport = _passportSearchRepository.GetPassportByName(model.UserName);
            if (passport != null)
            {
                return Guid.Empty;
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
                return Guid.Empty;
            }
            passport = new PassportEntity
            {
                UserName = model.UserName,
                Password = _encrypt.Encrypt(model.Password),
                SubscriberId = subscriber.Id
            };

            return _passportRepository.AddPassport(passport) ? subscriber.Id : Guid.Empty;
        }
    }
}
