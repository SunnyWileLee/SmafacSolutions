using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Models
{
    public class GoodsCategoryModel : TreeNodeModel
    {
        public GoodsCategoryModel()
        {
            Children = new List<GoodsCategoryModel>();
        }

        [MaxLength(100)]
        [Display(Name = "类别")]
        public string Name { get; set; }

        public List<GoodsCategoryModel> Children { get; set; }
    }
}
