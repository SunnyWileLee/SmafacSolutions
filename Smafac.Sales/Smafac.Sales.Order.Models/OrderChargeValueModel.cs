using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Models
{
    public class OrderChargeValueModel : SaasBaseModel
    {
        public Guid OrderId { get; set; }
        public Guid ChargeId { get; set; }
        public decimal Charge { get; set; }
        public string ChargeName { get; set; }
    }
}
