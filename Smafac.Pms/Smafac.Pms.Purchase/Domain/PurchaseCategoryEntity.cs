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
    [Table("PurchaseCategory")]
    class PurchaseCategoryEntity : CategoryEntity
    {
        public bool Saleable { get; set; }
        public bool Purchaseable { get; set; }
    }
}
