using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Models
{
    public class CustomerLevelModel : SaasBaseModel
    {
        public string Title { get; set; }
        public decimal Buttom { get; set; }
        public decimal Top { get; set; }
    }
}
