using Smafac.Framework.Models;
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
        public GoodsCategoryModel()
        {
            Children = new List<GoodsCategoryModel>();
        }

        public List<GoodsCategoryModel> Children { get; set; }
    }
}
