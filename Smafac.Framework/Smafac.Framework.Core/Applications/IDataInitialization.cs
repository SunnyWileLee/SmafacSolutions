using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Applications
{
    public interface IDataInitialization
    {
        void Init(Guid subscriberId);
    }
}
