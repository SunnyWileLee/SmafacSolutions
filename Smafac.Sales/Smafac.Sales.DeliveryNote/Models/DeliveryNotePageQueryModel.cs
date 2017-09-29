using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.DeliveryNote.Models
{
    public class DeliveryNotePageQueryModel : DateSpanPageQueryModel
    {
        [Display(Name = "客户")]
        [QueryProperty]
        public Guid CustomerId { get; set; }
        [Display(Name = "分类")]
        [QueryProperty]
        public Guid CategoryId { get; set; }
        protected override string DateColumn => "DeliveryTime";
    }
}
