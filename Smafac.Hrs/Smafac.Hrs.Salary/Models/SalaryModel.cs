using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Salary.Models
{
    public class SalaryModel : HavePropertyModel
    {
        public SalaryModel()
        {
            SalaryDate = DateTime.Now;
        }
        [Display(Name = "金额")]
        [Required]
        [ExportColumn]
        public decimal Amount { get; set; }
        [Display(Name = "类别")]
        public Guid CategoryId { get; set; }
        [Display(Name = "类别")]
        [ExportColumn]
        public string CategoryName { get; set; }
        [Display(Name = "薪水时间")]
        [Required]
        [ExportColumn]
        public DateTime SalaryDate { get; set; }
        public List<SalaryPropertyValueModel> Properties { get; set; }

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
