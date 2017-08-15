using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Account.Subscriber.Domain
{
    [Table("SignIn")]
    class SignInEntity : SaasBaseEntity
    {
        [MaxLength(50)]
        public string Token { get; set; }
        public Guid UserId { get; set; }
    }
}
