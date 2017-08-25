using Smafac.Account.Subscriber.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Account.Subscriber.Repositories
{
    class PassportSearchRepository : IPassportSearchRepository
    {
        private readonly ISubscriberContextProvider _subscriberContextProvider;

        public PassportSearchRepository(ISubscriberContextProvider subscriberContextProvider)
        {
            _subscriberContextProvider = subscriberContextProvider;
        }

        public PassportEntity GetPassportByName(string userName)
        {

            using (var context = _subscriberContextProvider.Provide())
            {
                try
                {
                    var passport = context.Passports.FirstOrDefault(s => s.UserName == userName);
                    return passport;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
