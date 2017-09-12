using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.DeliveryNote.Models
{
    public class DeliveryNoteDetailModel
    {

        public DeliveryNoteModel DeliveryNote { get; set; }
        public List<DeliveryNoteItemModel> DeliveryNoteItems { get; set; }

        public DeliveryNoteDetailModel()
        {
            DeliveryNoteItems = new List<DeliveryNoteItemModel>();
        }
    }
}
