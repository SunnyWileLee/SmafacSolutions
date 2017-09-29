using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Account.Subscriber.Models
{
    public class PassportModel : SaasBaseModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string SubscriberName { get; set; }
    }
}
