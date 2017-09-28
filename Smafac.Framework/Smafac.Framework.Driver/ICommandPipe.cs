using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Driver
{
    interface ICommandPipe
    {
        void Register<TCommandHandler>(TCommandHandler handler);
    }
}
