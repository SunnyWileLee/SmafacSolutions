using Smafac.Infrustructure.Log.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Infrustructure.Log.Repositories
{
    interface ILogAddRepository
    {
        bool AddLog(LogEntity log);
    }
}
