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

        protected override Dictionary<string, string> GetCustomizedColumns()
        {
            if (!HasProperties)
            {
                return new Dictionary<string, string>();
            }
            return Properties.ToDictionary(key => key.PropertyId.ToString(), value => value.PropertyName);
        }
    }
}
