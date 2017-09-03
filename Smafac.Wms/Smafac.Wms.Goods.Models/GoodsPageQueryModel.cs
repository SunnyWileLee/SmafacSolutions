using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Models
{
    public class GoodsPageQueryModel : PageQueryBaseModel
    {
        [Display(Name = "名称")]
        [QueryProperty(Compare = CompareType.Like)]
        public string Name { get; set; }
        [Display(Name = "分类")]
        [QueryProperty(Compare = CompareType.Equal)]
        public Guid CategoryId { get; set; }
    }
}
