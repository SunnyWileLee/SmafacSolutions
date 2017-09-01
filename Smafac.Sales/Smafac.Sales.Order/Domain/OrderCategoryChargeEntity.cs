using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Domain
{
    [Table("OrderCategoryCharge")]
    public class OrderCategoryChargeEntity : CategoryAssociationEntity
    {
        public Guid ChargeId { get; set; }
    }
}
