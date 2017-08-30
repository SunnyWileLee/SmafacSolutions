using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Domain
{
    public abstract class CategoryAssociationEntity : SaasBaseEntity
    {
        public virtual Guid CategoryId { get; set; }
    }
}
