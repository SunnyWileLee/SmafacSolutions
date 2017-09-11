using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.DeliveryNote.Models
{
    public class DeliveryNoteItemModel
    {
        public Guid DeliveryNoteId { get; set; }
        public Guid GoodsId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
    }
}
