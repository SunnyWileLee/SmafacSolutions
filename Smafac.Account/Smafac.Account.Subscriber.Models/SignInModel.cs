using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Account.Subscriber.Models
{
    public class SignInModel : SaasBaseModel
    {
        public string Token { get; set; }
        public Guid UserId { get; set; }
    }
}
