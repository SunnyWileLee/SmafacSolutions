using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Domain
{
    [Table("CustomerContact")]
    class CustomerContactEntity : SaasBaseEntity
    {
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }
    }
}
