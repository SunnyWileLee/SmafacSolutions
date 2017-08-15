using Smafac.Account.Subscriber.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Account.Subscriber.Applications
{
    public interface ISubscriberService
    {
        bool Register(PassportModel model);
    }
}
