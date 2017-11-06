using Smafac.Infrustructure.Log.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Infrustructure.Log.Applications
{
    public interface ILogAddService
    {
        void AddLog(LogModel model);
    }
}
