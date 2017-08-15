using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Models
{
    public class CustomerFinancialModel : SaasBaseModel
    {
        public Guid CustomerId { get; set; }
        public decimal Amount { get; set; }
        public string Evidence { get; set; }
        public string Memo { get; set; }
        public DateTime PayTime { get; set; }
        public Guid TypeId { get; set; }
        public Guid StatusId { get; set; }
        public Guid PayTypeId { get; set; }
    }
}
