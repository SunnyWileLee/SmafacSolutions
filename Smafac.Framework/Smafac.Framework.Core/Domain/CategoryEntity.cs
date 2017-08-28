using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Domain
{
    public abstract class CategoryEntity : TreeNodeEntity
    {
        [MaxLength(100)]
        public virtual string Name { get; set; }
    }
}
