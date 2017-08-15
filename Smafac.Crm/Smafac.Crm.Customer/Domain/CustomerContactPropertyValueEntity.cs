using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Domain
{
    [Table("CustomerContactPropertyValue")]
    class CustomerContactPropertyValueEntity : SaasBaseEntity
    {
        public Guid ContactId { get; set; }
        public Guid PropertyId { get; set; }
        public string Value { get; set; }
    }
}
