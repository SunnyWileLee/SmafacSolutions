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
    [Table("Passport")]
    class PassportEntity : SaasBaseEntity, ISignInCreater
    {
        [MaxLength(100)]
        public string UserName { get; set; }
        [MaxLength(100)]
        public string Password { get; set; }

        public bool VerifyPassword(string password)
        {
            if (string.IsNullOrEmpty(this.Password))
            {
                return true;
            }
            return Password.Equals(Password);
        }

        public SignInEntity CreateSignIn(Guid userId)
        {
            if (this.Id != userId)
            {
                throw new Exception("userid异常");
            }
            var signIn = new SignInEntity
            {
                SubscriberId = this.SubscriberId,
                Token = Guid.NewGuid().ToString().ToUpper().Replace("-", string.Empty),
                UserId = this.Id
            };
            return signIn;
        }
    }
}
