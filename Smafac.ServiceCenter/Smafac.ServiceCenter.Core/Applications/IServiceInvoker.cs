using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.ServiceCenter.Core.Applications
{
    public interface IServiceInvoker
    {
        string Invoke(string apiCode, string body);
    }
}
