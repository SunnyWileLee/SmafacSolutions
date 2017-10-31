using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Pms.Purchase.Models
{
    public class PurchaseModel : HavePropertyModel
    {
        [Display(Name = "商品")]
        [Required]
        public Guid GoodsId { get; set; }
        [Display(Name = "商品")]
        [Required]
        [ExportColumn]
        public string GoodsName { get; set; }
        [Display(Name = "数量")]
        [Required]
        [ExportColumn]
        public decimal Quantity { get; set; }
        [Display(Name = "金额")]
        [Required]
        [ExportColumn]
        public decimal Amount { get; set; }
        [Display(Name = "类别")]
        public Guid CategoryId { get; set; }
        [Display(Name = "类别")]
        [ExportColumn]
        public string CategoryName { get; set; }
        public List<PurchasePropertyValueModel> Properties { get; set; }

        public override IEnumerable<PropertyValueModel> PropertyValues
        {
            get
            {
                if (Properties == null)
                {
                    return new List<PropertyValueModel> { };
                }
                return Properties.Cast<PropertyValueModel>();
            }
        }
    }
}
