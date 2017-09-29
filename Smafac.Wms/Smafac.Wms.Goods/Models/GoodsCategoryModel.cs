using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Models
{
    public class GoodsCategoryModel : CategoryModel
    {
        [Display(Name = "可以销售")]
        public bool Saleable { get; set; }
        [Display(Name = "需要采购")]
        public bool Purchaseable { get; set; }
    }
}
