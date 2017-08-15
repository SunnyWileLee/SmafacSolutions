using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Domain
{
    class OrderEntity
    {
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Amount { get; set; }
    }
}
