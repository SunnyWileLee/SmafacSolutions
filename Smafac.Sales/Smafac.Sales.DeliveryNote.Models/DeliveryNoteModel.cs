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
        public DeliveryNoteModel()
        {
            Properties = new List<DeliveryNotePropertyValueModel>();
        }

        public Guid CustomerId { get; set; }
        [Display(Name = "客户")]
        public Guid CustomerName { get; set; }
        [Display(Name = "送货时间")]
        public DateTime DeliveryTime { get; set; }
        [Display(Name = "金额")]
        public decimal Amount { get; set; }
        [Display(Name = "分类")]
        public Guid CategoryId { get; set; }
        [Display(Name = "分类")]
        public string CategoryName { get; set; }
        [MaxLength(500)]
        [Display(Name = "备注")]
        public string Memo { get; set; }

        public List<DeliveryNotePropertyValueModel> Properties { get; set; }

        public bool HasProperties
        {
            get
            {
                return Properties != null && Properties.Any();
            }
        }
    }
}
