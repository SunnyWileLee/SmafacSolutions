using Smafac.Account.Subscriber.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Account.Subscriber.Repositories
{
    class SignInRepository : ISignInRepository
    {
        private readonly ISubscriberContextProvider _subscriberContextProvider;

        public SignInRepository(ISubscriberContextProvider subscriberContextProvider)
        {
            _subscriberContextProvider = subscriberContextProvider;
        }

        public SignInEntity GetByToken(string token)
        {
            using (var context = _subscriberContextProvider.Provide())
            {
                return context.SignIns.FirstOrDefault(s => s.Token == token);
            }
        }

        public bool AddSignIn(SignInEntity signIn)
        {
            using (var context = _subscriberContextProvider.Provide())
            {
                context.SignIns.Add(signIn);
                return context.SaveChanges() > 0;
            }
        }
    }
}
