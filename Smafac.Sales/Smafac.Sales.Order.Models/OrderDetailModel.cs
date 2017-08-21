using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Models
{
    public class OrderDetailModel : SaasBaseModel
    {
        public OrderModel Order { get; set; }
    }
}
