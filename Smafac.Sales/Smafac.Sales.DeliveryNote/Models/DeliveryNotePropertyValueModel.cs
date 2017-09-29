using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.DeliveryNote.Models
{
    public class DeliveryNotePropertyValueModel : PropertyValueModel
    {
        public Guid DeliveryNoteId { get; set; }
    }
}
