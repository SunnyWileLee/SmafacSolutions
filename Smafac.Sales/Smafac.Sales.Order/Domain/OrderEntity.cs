using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Domain
{
    [Table("Order")]
    class OrderEntity : SaasBaseEntity
    {
        public OrderEntity()
        {
            OrderDate = DateTime.Now;
            HopeDate = DateTime.Now;
        }
        public decimal Price { get; set; }
        public Guid CustomerId { get; set; }
        public Guid GoodsId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime HopeDate { get; set; }
        [MaxLength(500)]
        public string Memo { get; set; }
    }
}
