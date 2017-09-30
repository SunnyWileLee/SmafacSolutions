using Smafac.Account.FundCenter.Models;
using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Account.FundCenter.Domain
{
    [Table("Recharge")]
    class RechargeEntity : SaasBaseEntity
    {
        public decimal BeforeAmount { get; set; }
        public decimal Amount { get; set; }
        public decimal AfterAmount { get; set; }
        public SubscriberRechargeType Type { get; set; }
        public Guid PassportId { get; set; }
    }
}
