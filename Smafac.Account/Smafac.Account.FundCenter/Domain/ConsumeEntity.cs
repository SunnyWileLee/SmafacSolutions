using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Account.FundCenter.Domain
{
    [Table("Consume")]
    class ConsumeEntity : SaasBaseEntity
    {
        public decimal BeforeAmount { get; set; }
        public decimal AfterAmount { get; set; }
        public decimal Amount { get; set; }
        public Guid ConsumeThingId { get; set; }
        [MaxLength(100)]
        public string Memo { get; set; }
        public Guid PassportId { get; set; }
    }
}
