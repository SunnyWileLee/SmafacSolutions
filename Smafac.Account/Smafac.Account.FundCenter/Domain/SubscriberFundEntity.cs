using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Account.FundCenter.Domain
{
    [Table("SubscriberFund")]
    class SubscriberFundEntity : SaasBaseEntity
    {
        public decimal Balance { get; set; }
    }
}
