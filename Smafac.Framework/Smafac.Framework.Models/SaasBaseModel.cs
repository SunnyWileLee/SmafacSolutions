using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Smafac.Framework.Models
{
    public abstract class SaasBaseModel
    {
        public SaasBaseModel()
        {
            Id = Guid.NewGuid();
            CreateTime = DateTime.Now;
        }
        public virtual Guid Id { get; set; }
        public virtual Guid SubscriberId { get; set; }
        [Display(Name = "创建时间")]
        [ExportColumn]
        public virtual DateTime CreateTime { get; set; }
    }
}
