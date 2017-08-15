using Smafac.Account.Subscriber.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Account.Subscriber.Repositories
{
    class SubscriberSearchRepository : ISubscriberSearchRepository
    {

        private readonly ISubscriberContextProvider _subscriberContextProvider;

        public SubscriberSearchRepository(ISubscriberContextProvider subscriberContextProvider)
        {
            _subscriberContextProvider = subscriberContextProvider;
        }

        public SubscriberEntity GetSubscriberById(Guid id)
        {
            using (var context = _subscriberContextProvider.Provide())
            {
                var subscriber = context.Subscribers.FirstOrDefault(s => s.Id == id);
                return subscriber;
            }
        }
    }
}
