using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Infrustructure.Log.Domain;

namespace Smafac.Infrustructure.Log.Repositories
{
    class LogAddRepository : ILogAddRepository
    {
        private readonly ILogContextProvider _contextProvider;

        public LogAddRepository(ILogContextProvider contextProvider)
        {
            _contextProvider = contextProvider;
        }

        public bool AddLog(LogEntity log)
        {
            using (var context = _contextProvider.Provide())
            {
                context.Logs.Add(log);
                return context.SaveChanges() > 0;
            }
        }
    }
}
