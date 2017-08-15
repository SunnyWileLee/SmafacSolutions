using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Account.Subscriber.Repositories
{
    class SubscriberContextProvider : ISubscriberContextProvider
    {
        public SubscriberContext Provide()
        {
            return new SubscriberContext();
        }

        public SubscriberContext ProvideSlave()
        {
            return new SubscriberContext();
        }
    }
}
