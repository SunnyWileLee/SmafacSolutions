using Smafac.Account.Subscriber.Models;
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
    [Table("Subscriber")]
    class SubscriberEntity : SaasBaseEntity
    {
        [MaxLength(500)]
        public string Name { get; set; }

        public PassportEntity CreatePassport(PassportModel model)
        {
            return new PassportEntity
            {
                SubscriberId = this.Id,
                UserName = model.UserName,
                Password = model.Password
            };
        }
    }
}
