using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Models
{
    public class OrderPageQueryModel : PageQueryBaseModel
    {
        public OrderPageQueryModel()
        {

        }

        [Display(Name = "分类")]
        [QueryProperty]
        public Guid CategoryId { get; set; }
        [Display(Name = "客户")]
        [QueryProperty]
        public Guid CustomerId { get; set; }
        //[Display(Name = "开始时间")]
        //[QueryProperty]
        //public DateTime BeginDate { get; set; }
        //[Display(Name = "结束时间")]
        //[QueryProperty]
        //public DateTime EndDate { get; set; }
    }
}
