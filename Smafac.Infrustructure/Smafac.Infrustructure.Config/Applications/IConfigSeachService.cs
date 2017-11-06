using Smafac.Infrustructure.Config.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Infrustructure.Config.Applications
{
    public interface IConfigSeachService
    {
        string Get(string key);
        List<ConfigModel> Get();
    }
}
