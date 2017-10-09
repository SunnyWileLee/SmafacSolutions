using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Driver
{
    class PipeServiceMethodDescriptor
    {
        public PipeServiceMethodDescriptor(MethodInfo method)
        {
            Method = method;
        }
        public MethodInfo Method { get;  }
    }
}
