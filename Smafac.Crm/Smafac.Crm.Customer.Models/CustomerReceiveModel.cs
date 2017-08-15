using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Models
{
    public class CustomerReceiveModel : SaasBaseModel
    {
        public Guid InvokerId { get; set; }
        public DateTime ReceiveTime { get; set; }
        public Guid CustomerId { get; set; }
        public decimal Cost { get; set; }
        public string Content { get; set; }
        public string Memo { get; set; }
    }
}
