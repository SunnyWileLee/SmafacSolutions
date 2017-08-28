using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Domain
{
    public abstract class PropertyUsedByValueChecker: PropertyUsedChecker
    {


        public override bool Check(Guid entityId)
        {
            throw new NotImplementedException();
        }
    }
}
