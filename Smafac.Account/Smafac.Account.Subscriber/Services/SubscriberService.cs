using Smafac.Account.Subscriber.Applications;
using Smafac.Account.Subscriber.Domain;
using Smafac.Account.Subscriber.Models;
using Smafac.Account.Subscriber.Repositories;
using Smafac.Framework.Core.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Account.Subscriber.Services
{
    class SubscriberService : ISubscriberService
    {
        private readonly ISubscriberRegister _subscriberRegister;
        private readonly IDataInitialization[] _dataInitializations;

        public SubscriberService(ISubscriberRegister subscriberRegister,
                                IDataInitialization[] dataInitializations)
        {
            _subscriberRegister = subscriberRegister;
            _dataInitializations = dataInitializations;
        }

        public bool Register(PassportModel model)
        {
            var subscriberId = _subscriberRegister.Register(model);
            var success = subscriberId != Guid.Empty;
            if (success && _dataInitializations.Any())
            {
                _dataInitializations.ToList().ForEach(
                    initialization =>
                    {
                        initialization.Init(subscriberId);
                    });
            }
            return success;
        }
    }
}
