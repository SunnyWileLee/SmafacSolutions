using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Models
{
    public class CategoryModel : TreeNodeModel
    {
        [MaxLength(100)]
        [Display(Name = "类别")]
        public string Name { get; set; }
    }
}
