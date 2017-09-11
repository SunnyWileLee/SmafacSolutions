using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.DeliveryNote.Models
{
    public class DeliveryNoteModel : SaasBaseModel
    {
        public Guid CustomerId { get; set; }
        public Guid DeliveryTime { get; set; }
        public decimal Amount { get; set; }
        public Guid CategoryId { get; set; }
        [MaxLength(500)]
        public string Memo { get; set; }
    }
}
