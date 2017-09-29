using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.CustomerFinance.Models
{
    public class CustomerFinanceModel : HavePropertyModel
    {
        public CustomerFinanceModel()
        {
            FinanceTime = DateTime.Now;
        }

        [Display(Name = "客户")]
        public Guid CustomerId { get; set; }
        [Display(Name = "客户")]
        [ExportColumn]
        public string CustomerName { get; set; }
        [Display(Name = "金额")]
        [ExportColumn]
        public decimal Amount { get; set; }
        [Display(Name = "时间")]
        [ExportColumn]
        public DateTime FinanceTime { get; set; }
        [Display(Name = "备注")]
        [ExportColumn]
        public string Memo { get; set; }
        [Display(Name = "类别")]
        public Guid CategoryId { get; set; }
        [Display(Name = "类别")]
        [ExportColumn]
        public string CategoryName { get; set; }

        public List<CustomerFinancePropertyValueModel> Properties { get; set; }

        public override IEnumerable<PropertyValueModel> PropertyValues
        {
            get
            {
                if (Properties == null)
                {
                    return new List<PropertyValueModel> { };
                }
                return Properties.Cast<PropertyValueModel>();
            }
        }
    }
}
