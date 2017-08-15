using Smafac.Account.Subscriber.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Account.Subscriber.Repositories
{
    class SubscriberRepository : ISubscriberRepository
    {

        private readonly ISubscriberContextProvider _subscriberContextProvider;

        public SubscriberRepository(ISubscriberContextProvider subscriberContextProvider)
        {
            _subscriberContextProvider = subscriberContextProvider;
        }

        public bool AddSubscriber(SubscriberEntity subscriber)
        {
            using (var context = _subscriberContextProvider.Provide())
            {
                context.Subscribers.Add(subscriber);
                return context.SaveChanges() > 0;
            }
        }
    }
}
