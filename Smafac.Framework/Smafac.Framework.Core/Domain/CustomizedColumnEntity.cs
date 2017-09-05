using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Domain
{
    public abstract class CustomizedColumnEntity : SaasBaseEntity
    {
        public CustomizedColumnEntity()
        {
            IsTableColumn = false;
            IsDeleteAssociations = false;
        }

        [MaxLength(20)]
        public string Name { get; set; }
        public bool IsTableColumn { get; set; }
        public bool IsDeleteAssociations { get; set; }
    }
}
