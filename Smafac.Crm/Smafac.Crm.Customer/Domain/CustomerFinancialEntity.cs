using Smafac.Crm.Customer.Models;
using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Domain
{
    [Table("CustomerFinancial")]
    class CustomerFinancialEntity : SaasBaseEntity
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
