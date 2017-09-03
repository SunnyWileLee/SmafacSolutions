using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Models
{
    public class CustomerPageQueryModel : PageQueryBaseModel
    {
        [Display(Name = "名称")]
        [QueryProperty(Compare = CompareType.Like)]
        public string Name { get; set; }
        [Display(Name = "联系方式")]
        [QueryProperty(Compare = CompareType.Like)]
        public string MobileNumber { get; set; }
    }
}
