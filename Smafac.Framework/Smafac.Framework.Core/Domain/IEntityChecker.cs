using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Domain
{
    public interface IEntityChecker
    {
        bool Check(Guid entityId);
    }
}
