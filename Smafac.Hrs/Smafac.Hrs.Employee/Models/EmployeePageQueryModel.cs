using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Employee.Models
{
    public class EmployeePageQueryModel : DateSpanPageQueryModel
    {
        [Display(Name = "分类")]
        [QueryProperty(Compare = CompareType.Equal)]
        public Guid CategoryId { get; set; }
        [QueryProperty(Compare = CompareType.Equal)]
        public Guid GoodsId { get; set; }

        protected override string DateColumn => "EmployeeDate";
    }
}
