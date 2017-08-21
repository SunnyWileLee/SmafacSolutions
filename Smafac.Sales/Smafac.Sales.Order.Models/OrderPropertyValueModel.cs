using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Models
{
    public class OrderPropertyValueModel : PropertyValueModel
    {
        public Guid OrderId { get; set; }
    }
}
