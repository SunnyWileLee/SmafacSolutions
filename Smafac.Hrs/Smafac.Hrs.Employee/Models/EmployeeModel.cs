using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Employee.Models
{
    public class EmployeeModel : HavePropertyModel
    {
        public EmployeeModel()
        {
            EmployeeDate = DateTime.Now;
        }
        [Display(Name = "姓名")]
        [Required]
        [ExportColumn]
        public string Name { get; set; }
        [Display(Name = "身份证")]
        [Required]
        [ExportColumn]
        public string Identity { get; set; }
        [Display(Name = "手机号码")]
        [Required]
        [ExportColumn]
        public string Phone { get; set; }
        [Display(Name = "类别")]
        public Guid CategoryId { get; set; }
        [Display(Name = "类别")]
        [ExportColumn]
        public string CategoryName { get; set; }
        [Display(Name = "入职时间")]
        [Required]
        [ExportColumn]
        public DateTime EmployeeDate { get; set; }
        public List<EmployeePropertyValueModel> Properties { get; set; }

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
