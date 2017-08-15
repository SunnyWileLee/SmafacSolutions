using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Domain
{
    class CustomerAfterServiceEntity : SaasBaseEntity
    {
        public Guid InvokerId { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime ServiceTime { get; set; }
        public decimal Cost { get; set; }
        public string Content { get; set; }
        public string Memo { get; set; }
    }
}
