using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Domain
{
    public class StatusChangedEntity : SaasBaseEntity
    {
        public Guid StatusBefore { get; set; }
        public Guid StatusAfter { get; set; }
    }
}
