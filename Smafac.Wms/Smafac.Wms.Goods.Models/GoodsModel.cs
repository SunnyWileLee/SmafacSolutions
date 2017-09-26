using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Models
{
    public class GoodsModel : SaasBaseModel
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
        public List<GoodsPropertyValueModel> Properties { get; set; }

        public bool HasProperties
        {
            get
            {
                return Properties != null && Properties.Any();
            }
        }

        public override string GetValue(string column)
        {
            if (!HasProperties)
            {
                return string.Empty;
            }
            var property = Properties.FirstOrDefault(s => s.PropertyId.Equals(Guid.Parse(column)));
            return property == null ? string.Empty : property.Value;
        }
    }
}
