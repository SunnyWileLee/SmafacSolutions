using Smafac.Infrustructure.Log.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Infrustructure.Log.Models;
using Smafac.Infrustructure.Log.Repositories;
using Smafac.Infrustructure.Log.Domain;
using AutoMapper;

namespace Smafac.Infrustructure.Log.Services
{
    class LogAddService : ILogAddService
    {
        private readonly ILogAddRepository _logAddRepository;

        public LogAddService(ILogAddRepository logAddRepository)
        {
            _logAddRepository = logAddRepository;
        }

        public void AddLog(LogModel model)
        {
            var action = new Action<LogModel>(this.AddLogTask);
            action.BeginInvoke(model, null, null);
        }

        private void AddLogTask(LogModel model)
        {
            var log = Mapper.Map<LogEntity>(model);
            _logAddRepository.AddLog(log);
        }
    }
}
