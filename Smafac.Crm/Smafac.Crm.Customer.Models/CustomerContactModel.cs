using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Models
{
    public class CustomerContactModel : SaasBaseModel
    {
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }
    }
}
