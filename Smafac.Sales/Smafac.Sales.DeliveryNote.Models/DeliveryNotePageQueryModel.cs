using Smafac.Framework.Models;
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
        public Guid CustomerId { get; set; }
        [Display(Name = "分类")]
        public Guid CategoryId { get; set; }

        protected override string DateColumn => "DeliveryTime";
    }
}
