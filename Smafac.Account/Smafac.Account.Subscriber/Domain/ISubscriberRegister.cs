using Smafac.Account.Subscriber.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Account.Subscriber.Domain
{
    interface ISubscriberRegister
    {
        Guid Register(PassportModel model);
    }
}
