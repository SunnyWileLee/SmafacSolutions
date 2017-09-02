using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.CustomerFinance.Domain
{
    [Table("CustomerFinance")]
    class CustomerFinanceEntity : SaasBaseEntity
    {
        public Guid CategoryId { get; set; }
        public Guid CustomerId { get; set; }
        public decimal Amount { get; set; }
        public DateTime FinanceTime { get; set; }
        public string Memo { get; set; }
    }
}
