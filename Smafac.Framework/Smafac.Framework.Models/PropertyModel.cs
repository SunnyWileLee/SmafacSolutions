using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Models
{
    public class PropertyModel : CustomizedColumnModel
    {
        [Display(Name="类型")]
        public PropertyType Type { get; set; }
    }
}
