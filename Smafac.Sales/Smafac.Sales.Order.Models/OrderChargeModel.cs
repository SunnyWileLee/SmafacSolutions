using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Models
{
    public class OrderChargeModel : CustomizedColumnModel
    {
        [MaxLength(20)]
        [Required]
        [Display(Name = "费用")]
        public override string Name { get; set; }
    }
}
