using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.DeliveryNote.Models
{
    public class DeliveryNoteDetailModel
    {
        public DeliveryNoteItemModel ItemModel { get; set; }

        public DeliveryNoteModel DeliveryNote { get; set; }
        public List<DeliveryNoteItemModel> Items { get; set; }

        public DeliveryNoteDetailModel()
        {
            Items = new List<DeliveryNoteItemModel>();
            ItemTableColumns = new List<CustomizedColumnModel>();
            ItemProperties = new List<DeliveryNoteItemPropertyModel>();
        }

        public List<CustomizedColumnModel> ItemTableColumns { get; set; }
        public List<DeliveryNoteItemPropertyModel> ItemProperties { get; set; }
    }
}
