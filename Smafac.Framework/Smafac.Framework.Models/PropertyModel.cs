using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Models
{
    public class PropertyModel : SaasBaseModel
    {
        public const string TableColumnOn = "on";
        private string _isTableColumnOn;

        public PropertyModel()
        {
            IsTableColumn = false;
        }
        [MaxLength(20)]
        [Required]
        public string Name { get; set; }
        public PropertyType Type { get; set; }
        public bool IsTableColumn { get; set; }
        public string IsTableColumnOn
        {
            get
            {
                return _isTableColumnOn;
            }
            set
            {
                _isTableColumnOn = value;
                IsTableColumn = TableColumnOn.Equals(value);
            }
        }
    }
}
