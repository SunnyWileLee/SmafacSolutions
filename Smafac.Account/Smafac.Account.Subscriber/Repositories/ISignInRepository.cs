using Smafac.Account.Subscriber.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Account.Subscriber.Repositories
{
    interface ISignInRepository
    {
        SignInEntity GetByToken(string token);
        bool AddSignIn(SignInEntity signIn);
    }
}
