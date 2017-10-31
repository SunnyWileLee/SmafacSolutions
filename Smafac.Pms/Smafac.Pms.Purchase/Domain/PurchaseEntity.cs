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
        [MaxLength(100)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
    }
}
