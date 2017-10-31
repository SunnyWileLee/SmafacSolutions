using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Pms.Purchase.Models
{
    public class PurchasePageQueryModel : DateSpanPageQueryModel
    {
        [Display(Name = "分类")]
        [QueryProperty(Compare = CompareType.Equal)]
        public Guid CategoryId { get; set; }

        protected override string DateColumn => "PurchaseDate";
    }
}
