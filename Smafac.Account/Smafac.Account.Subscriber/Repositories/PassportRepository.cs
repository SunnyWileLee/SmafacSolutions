using Smafac.Account.Subscriber.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Account.Subscriber.Repositories
{
    class PassportRepository : IPassportRepository
    {
        private readonly ISubscriberContextProvider _subscriberContextProvider;

        public PassportRepository(ISubscriberContextProvider subscriberContextProvider)
        {
            _subscriberContextProvider = subscriberContextProvider;
        }

        public bool AddPassport(PassportEntity passport)
        {
            using (var context = _subscriberContextProvider.Provide())
            {
                context.Passports.Add(passport);
                return context.SaveChanges() > 0;
            }
        }
    }
}
