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
    [Table("ConsumeThing")]
    class ConsumeThingEntity : SaasBaseEntity
    {
        public decimal Price { get; set; }
        public ConsumeThingType Type { get; set; }
        public string Description { get; set; }
        public bool Onsale { get; set; }
    }
}
