using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Models
{
    public class CustomerPropertyValueModel : PropertyValueModel
    {
        public Guid CustomerId { get; set; }
    }
}
