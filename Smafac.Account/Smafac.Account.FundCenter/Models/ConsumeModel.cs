using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Account.FundCenter.Models
{
    public class ConsumeModel
    {
        public decimal Amount { get; set; }
        public Guid ConsumeThingId { get; set; }
        public Guid PassportId { get; set; }
    }
}
