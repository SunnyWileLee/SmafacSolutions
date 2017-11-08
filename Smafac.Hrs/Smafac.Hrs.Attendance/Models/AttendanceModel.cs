using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Attendance.Models
{
    public class AttendanceModel : HavePropertyModel
    {
        public AttendanceModel()
        {
            BeginTime = DateTime.Now.Date.AddHours(8);
            BeginTime = DateTime.Now.Date.AddHours(17);
        }
        [Display(Name = "开始时间")]
        [Required]
        [ExportColumn]
        public DateTime BeginTime { get; set; }
        [Display(Name = "结束时间")]
        [Required]
        [ExportColumn]
        public DateTime EndTime { get; set; }
        [Display(Name = "类别")]
        public Guid CategoryId { get; set; }
        [Display(Name = "类别")]
        [ExportColumn]
        public string CategoryName { get; set; }
        public List<AttendancePropertyValueModel> Properties { get; set; }

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
