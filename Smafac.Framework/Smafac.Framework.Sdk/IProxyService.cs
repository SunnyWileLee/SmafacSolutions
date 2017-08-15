using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Sdk
{
    public interface IProxyService
    {
        ResponseModel Proxy(RequestModel request);
    }
}
