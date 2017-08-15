using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Models
{
    public class CustomerModel : SaasBaseModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime KnownDate { get; set; }
        public string MobileNumber { get; set; }
        public Guid LevelId { get; set; }
    }
}
