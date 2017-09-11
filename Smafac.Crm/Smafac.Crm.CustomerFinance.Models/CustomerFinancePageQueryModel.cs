using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.CustomerFinance.Models
{
    public class CustomerFinancePageQueryModel : PageQueryBaseModel
    {
        public CustomerFinancePageQueryModel()
        {
            BeginDate = DateTime.Now.Date;
            EndDate = DateTime.Now.Date.AddDays(1).AddSeconds(-1);
        }

        [Display(Name = "分类")]
        [QueryProperty]
        public Guid CategoryId { get; set; }
        [Display(Name = "客户")]
        [QueryProperty]
        public Guid CustomerId { get; set; }
        [Display(Name = "开始日期")]
        public DateTime BeginDate { get; set; }
        [Display(Name = "结束日期")]
        public DateTime EndDate { get; set; }
    }
}
