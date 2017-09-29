using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Models
{
    public  class CustomizedColumnModel : SaasBaseModel
    {
        public CustomizedColumnModel()
        {
            IsTableColumn = false;
            IsDeleteAssociations = false;
        }
        [MaxLength(20)]
        [Required]
        [Display(Name= "属性名称")]
        public virtual string Name { get; set; }
        [Display(Name = "显示在列表")]
        public virtual bool IsTableColumn { get; set; }
        [Display(Name = "关联删除")]
        public virtual bool IsDeleteAssociations { get; set; }
    }
}
