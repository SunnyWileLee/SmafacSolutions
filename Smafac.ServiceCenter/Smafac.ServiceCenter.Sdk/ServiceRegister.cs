using Smafac.ServiceCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Smafac.Framework.Infrustructure;

namespace Smafac.ServiceCenter.Sdk
{
    class ServiceRegister : IServiceRegister
    {
        private readonly IHttpInvoker _httpInvoker;
        public ServiceRegister(IHttpInvoker httpInvoker)
        {
            _httpInvoker = httpInvoker;
        }

        public bool Register(ServiceModel service, IEnumerable<ApiModel> apis)
        {
            ApiCollectionModel model = new ApiCollectionModel
            {
                Service = service,
                Apis = apis
            };
            var json = JsonConvert.SerializeObject(model);
            var url = StaticConfigs.ServiceCenterDomain + "/Register/Register";
            var result = _httpInvoker.Invoke(url, json);
            return true;
        }
    }
}
