using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Models
{
    public class CustomerPropertyValueModel : SaasBaseModel
    {
        public Guid CustomerId { get; set; }
        public Guid PropertyId { get; set; }
        public string PropertyName { get; set; }
        public string Value { get; set; } 
    }
}
