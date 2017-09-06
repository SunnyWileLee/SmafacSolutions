using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Models
{
    public class OrderModel : SaasBaseModel
    {
        public OrderModel()
        {
            OrderDate = DateTime.Now;
            HopeDate = DateTime.Now;
        }
        [Display(Name = "客户")]
        public Guid CustomerId { get; set; }
        public Guid GoodsId { get; set; }
        [Display(Name = "单价")]
        [Required]
        public decimal Price { get; set; }
        [Display(Name = "数量")]
        [Required]
        public decimal Quantity { get; set; }
        [Display(Name = "金额")]
        [Required]
        public decimal Charge { get; set; }
        [Display(Name = "总价")]
        public decimal TotalCharge { get; set; }
        [Display(Name = "下单日期")]
        public DateTime OrderDate { get; set; }
        [Display(Name = "交货日期")]
        public DateTime HopeDate { get; set; }
        [MaxLength(500)]
        [Display(Name = "备注")]
        public string Memo { get; set; }
        [Display(Name = "客户")]
        public string CustomerName { get; set; }
        [Display(Name = "商品")]
        public string GoodsName { get; set; }
        [Display(Name = "类别")]
        public Guid CategoryId { get; set; }
        [Display(Name = "类别")]
        public string CategoryName { get; set; }

        public List<OrderChargeValueModel> Charges { get; set; }
        public List<OrderPropertyValueModel> Properties { get; set; }

        public bool HasCharges
        {
            get
            {
                return Charges != null && Charges.Any();
            }
        }

        public bool HasProperties
        {
            get
            {
                return Properties != null && Properties.Any();
            }
        }
    }
}
