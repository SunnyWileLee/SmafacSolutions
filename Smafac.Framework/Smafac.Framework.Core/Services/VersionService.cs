using Smafac.Framework.Core.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Services
{
    public abstract class VersionService : IVersionService
    {
        public const int DefaultVersion = 1;

        public virtual int Version => DefaultVersion;
    }
}
