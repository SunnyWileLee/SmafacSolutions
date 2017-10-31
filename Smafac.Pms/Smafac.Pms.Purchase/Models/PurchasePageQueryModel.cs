using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Pms.Purchase.Models
{
    public class PurchasePageQueryModel : PageQueryBaseModel
    {
        [Display(Name = "名称")]
        [QueryProperty(Compare = CompareType.Like)]
        public string Name { get; set; }
        [Display(Name = "分类")]
        [QueryProperty(Compare = CompareType.Equal)]
        public Guid CategoryId { get; set; }
    }
}
