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
        public string Name { get; set; }
        public bool IsTableColumn { get; set; }
        public bool IsDeleteAssociations { get; set; }


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
