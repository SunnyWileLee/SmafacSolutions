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
        private readonly ISubscriberRegister _subscriberRegister;

        public SubscriberService(ISubscriberRegister subscriberRegister)
        {
            _subscriberRegister = subscriberRegister;
        }

        public bool Register(PassportModel model)
        {
            var id = _subscriberRegister.Register(model);
            return id != Guid.Empty;
        }
    }
}
