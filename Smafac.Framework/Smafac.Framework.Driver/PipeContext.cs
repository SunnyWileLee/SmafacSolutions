using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Driver
{
    public abstract class PipeContext : IPipeContext
    {
        public virtual PipeRequest Request { get; set; }
        public virtual PipeResponse Response { get; set; }
    }
}
