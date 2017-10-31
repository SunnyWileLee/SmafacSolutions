using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Pms.Purchase.Domain
{
    [Table("Purchase")]
    class PurchaseEntity : SaasBaseEntity
    {
        public PurchaseEntity()
        {
            PurchaseDate = DateTime.Now;
        }

        public Guid GoodsId { get; set; }
        public DateTime PurchaseDate { get; set; } 
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
        public Guid CategoryId { get; set; }
    }
}
