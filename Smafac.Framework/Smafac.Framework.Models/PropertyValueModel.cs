using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Models
{
    public class PropertyValueModel : SaasBaseModel
    {
        public Guid PropertyId { get; set; }
        [MaxLength(100)]
        public string Value { get; set; }
        [MaxLength(20)]
        public string PropertyName { get; set; }
        public bool IsTableColumn { get; set; }
        public PropertyType Type { get; set; }
    }
}
