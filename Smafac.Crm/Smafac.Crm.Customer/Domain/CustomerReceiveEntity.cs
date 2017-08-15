using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Domain
{
    [Table("CustomerReceive")]
    class CustomerReceiveEntity : SaasBaseEntity
    {
        public Guid InvokerId { get; set; }
        public DateTime ReceiveTime { get; set; }
        public Guid CustomerId { get; set; }
        public decimal Cost { get; set; }
        public string Content { get; set; }
        public string Memo { get; set; }
    }
}
