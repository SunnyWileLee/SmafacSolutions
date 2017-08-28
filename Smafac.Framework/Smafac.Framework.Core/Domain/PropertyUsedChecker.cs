using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Domain
{
    public abstract class PropertyUsedChecker : IEntityUsedChecker
    {
        public abstract bool Check(Guid entityId);
    }
}
