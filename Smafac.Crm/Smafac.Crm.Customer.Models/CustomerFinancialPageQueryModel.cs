using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Models
{
    public class CustomerFinancialPageQueryModel : PageQueryBaseModel
    {
        public Guid CustomerId { get; set; }
        public Guid TypeId { get; set; }
        public Guid StatusId { get; set; }
        public Guid PayTypeId { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
