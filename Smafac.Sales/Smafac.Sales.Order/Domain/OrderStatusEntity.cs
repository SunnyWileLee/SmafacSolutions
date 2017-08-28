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
    [Table("OrderStatus")]
    class OrderStatusEntity : SaasBaseEntity
    {
        [MaxLength(10)]
        public string Name { get; set; }
    }
}
