﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Account.Subscriber.Domain
{
    interface ISignInCreater
    {
        SignInEntity CreateSignIn(Guid userId);
    }
}
