using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Driver
{
    class CommandPipeProvider : ICommandPipeProvider
    {
        public CommandPipe Provide()
        {
            return new DefaultCommandPipe();
        }
    }
}
