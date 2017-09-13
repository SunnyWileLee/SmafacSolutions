using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.DeliveryNote.Models
{
    public class DeliveryNoteItemModel : SaasBaseModel
    {
        public DeliveryNoteItemModel()
        {
        }

        public Guid DeliveryNoteId { get; set; }
        [Display(Name = "商品")]
        public Guid GoodsId { get; set; }
        [Display(Name = "商品")]
        public string GoodsName { get; set; }
        [Display(Name = "数量")]
        public decimal Quantity { get; set; }
        [Display(Name = "金额")]
        public decimal Amount { get; set; }

        public List<DeliveryNoteItemPropertyValueModel> Properties { get; set; }

        public bool HasProperties
        {
            get
            {
                return Properties != null && Properties.Any();
            }
        }
    }
}
