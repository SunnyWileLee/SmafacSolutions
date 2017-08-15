using Smafac.Framework.Infrustructure;
using Smafac.ServiceCenter.Core.Applications;
using Smafac.ServiceCenter.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.ServiceCenter.Core.Services
{
    class ServiceInvoker : IServiceInvoker
    {
        private readonly IApiFinder _apiFinder;
        private readonly IServiceFinder _serviceFinder;
        private readonly IHttpInvoker _httpInvoker;

        public ServiceInvoker(IApiFinder apiFinder, IServiceFinder serviceFinder, IHttpInvoker httpInvoker)
        {
            _apiFinder = apiFinder;
            _serviceFinder = serviceFinder;
            _httpInvoker = httpInvoker;
        }

        public string Invoke(string apiCode, string body)
        {
            var api = _apiFinder.Find(apiCode);
            var service = _serviceFinder.Find(api.ServiceId);
            ApiContext context = new ApiContext
            {
                ApiDescription = api,
                ServiceDescription = service,
                Body = body
            };
            return _httpInvoker.Invoke(context.RequestUrl, body);
        }
    }
}
