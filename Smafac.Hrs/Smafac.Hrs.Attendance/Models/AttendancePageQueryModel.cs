using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Smafac.Hrs.Attendance.Models
{
    public class AttendancePageQueryModel : PageQueryBaseModel
    {
        [Display(Name = "分类")]
        [QueryProperty(Compare = CompareType.Equal)]
        public Guid CategoryId { get; set; }
        
        [Display(Name = "员工")]
        [QueryProperty(Compare = CompareType.Equal)]
        public Guid EmployeeId { get; set; }
    }
}
