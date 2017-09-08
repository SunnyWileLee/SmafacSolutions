using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Domain.CustomizedColumn
{
    public abstract class CustomizedColumnEntity : SaasBaseEntity
    {
        public CustomizedColumnEntity()
        {
            IsTableColumn = false;
            IsDeleteAssociations = false;
        }

        [MaxLength(20)]
        public virtual string Name { get; set; }
        public virtual bool IsTableColumn { get; set; }
        public virtual bool IsDeleteAssociations { get; set; }
    }
}
