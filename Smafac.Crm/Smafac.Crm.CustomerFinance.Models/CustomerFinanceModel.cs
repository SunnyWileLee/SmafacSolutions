using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.CustomerFinance.Models
{
    public class CustomerFinanceModel : SaasBaseModel
    {
        public CustomerFinanceModel()
        {
            FinanceTime = DateTime.Now;
        }

        [Display(Name = "客户")]
        public Guid CustomerId { get; set; }
        [Display(Name = "客户")]
        public string CustomerName { get; set; }
        [Display(Name = "金额")]
        public decimal Amount { get; set; }
        [Display(Name = "时间")]
        public DateTime FinanceTime { get; set; }
        [Display(Name = "备注")]
        public string Memo { get; set; }
        [Display(Name = "类别")]
        public Guid CategoryId { get; set; }
        [Display(Name = "类别")]
        public string CategoryName { get; set; }

        public List<CustomerFinancePropertyValueModel> Properties { get; set; }

        public bool HasProperties
        {
            get
            {
                return Properties != null && Properties.Any();
            }
        }
    }
}
