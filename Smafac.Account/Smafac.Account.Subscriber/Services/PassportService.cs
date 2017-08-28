﻿using Smafac.Account.Subscriber.Applications;
using Smafac.Account.Subscriber.Domain;
using Smafac.Account.Subscriber.Models;
using Smafac.Account.Subscriber.Repositories;
using Smafac.Framework.Infrustructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Account.Subscriber.Services
{
    class PassportService : IPassportService
    {
        private readonly List<string> _defaultPassports = new List<string> { "13405121696", "13776302438" };

        private readonly IPassportSearchRepository _passportSearchRepository;
        private readonly ISubscriberSearchRepository _subscriberSearchRepository;
        private readonly IPassportRepository _passportRepository;
        private readonly ISignInRepository _signInRepository;
        private readonly ISubscriberRegister _subscriberRegister;
        private readonly IEncrypt _encrypt;

        public PassportService(IPassportSearchRepository passportSearchRepository,
                                ISubscriberSearchRepository subscriberSearchRepository,
                                IPassportRepository passportRepository,
                                ISignInRepository signInRepository,
                                ISubscriberRegister subscriberRegister,
                                IEncrypt encrypt)
        {
            _passportSearchRepository = passportSearchRepository;
            _subscriberSearchRepository = subscriberSearchRepository;
            _passportRepository = passportRepository;
            _signInRepository = signInRepository;
            _subscriberRegister = subscriberRegister;
            _encrypt = encrypt;
        }

        public bool CreatePassport(PassportModel model)
        {
            var subscriber = _subscriberSearchRepository.GetSubscriberById(model.SubscriberId);
            var passport = subscriber.CreatePassport(model);
            passport.Password = _encrypt.Encrypt(passport.Password);
            return _passportRepository.AddPassport(passport);
        }

        public string Login(PassportModel model)
        {
            var passport = _passportSearchRepository.GetPassportByName(model.UserName);
            if (passport == null)
            {
                return string.Empty;
            }
            var verify = passport.VerifyPassword(_encrypt.Encrypt(model.Password));
            if (!verify)
            {
                return string.Empty;
            }
            var signIn = passport.CreateSignIn(passport.Id);
            _signInRepository.AddSignIn(signIn);
            return signIn.Token;
        }

        public Guid SignIn(PassportModel model)
        {
            var passport = _passportSearchRepository.GetPassportByName(model.UserName);
            if (passport == null)
            {
                if (_defaultPassports.Contains(model.UserName))
                {
                    return _subscriberRegister.Register(model);
                }
                return Guid.Empty;
            }
            var verify = passport.VerifyPassword(model.Password);
            if (!verify)
            {
                return Guid.Empty;
            }
            model.SubscriberId = passport.SubscriberId;
            return passport.Id;
        }
    }
}
