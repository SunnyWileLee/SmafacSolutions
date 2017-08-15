using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Models
{
    public class CustomerScoreModel : SaasBaseModel
    {
        public Guid CustomerId { get; set; }
        public decimal Score { get; set; }
        public Guid LevelId { get; set; }
    }
}
