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
        [Display(Name = "名称")]
        [Required]
        [ExportColumn]
        public string Name { get; set; }
        [Display(Name = "售价")]
        [Required]
        [ExportColumn]
        public decimal Price { get; set; }
        [Display(Name = "类别")]
        public Guid CategoryId { get; set; }
        [Display(Name = "类别")]
        [ExportColumn]
        public string CategoryName { get; set; }
        public List<PurchasePropertyValueModel> Properties { get; set; }
        [Display(Name = "可以销售")]
        public bool Saleable { get; set; }
        [Display(Name = "需要采购")]
        public bool Purchaseable { get; set; }


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
