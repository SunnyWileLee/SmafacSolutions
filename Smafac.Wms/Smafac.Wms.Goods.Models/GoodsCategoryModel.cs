using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Models
{
    public class GoodsCategoryModel : RecursionModel
    {
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
