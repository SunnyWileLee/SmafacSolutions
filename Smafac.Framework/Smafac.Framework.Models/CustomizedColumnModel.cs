using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Models
{
    public class CustomizedColumnModel : SaasBaseModel
    {
        public const string CheckboxOn = "on";
        private string _isTableColumnOn;
        private string _isDeleteAssociations;

        public CustomizedColumnModel()
        {
            IsTableColumn = false;
            IsDeleteAssociations = false;
        }
        [MaxLength(20)]
        [Required]
        [Display(Name= "属性名称")]
        public string Name { get; set; }
        public bool IsTableColumn { get; set; }
        public bool IsDeleteAssociations { get; set; }
        [Display(Name = "显示在列表")]
        public string IsTableColumnOn
        {
            get
            {
                return _isTableColumnOn;
            }
            set
            {
                _isTableColumnOn = value;
                IsTableColumn = CheckboxOn.Equals(value);
            }
        }
        [Display(Name = "关联删除")] 
        public string IsDeleteAssociationsOn
        {
            get
            {
                return _isDeleteAssociations;
            }
            set
            {
                _isDeleteAssociations = value;
                IsDeleteAssociations = CheckboxOn.Equals(value);
            }
        }
    }
}
