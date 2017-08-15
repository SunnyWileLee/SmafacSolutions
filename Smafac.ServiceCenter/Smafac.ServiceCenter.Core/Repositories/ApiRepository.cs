using Smafac.ServiceCenter.Core.Domain;
using Smafac.ServiceCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.ServiceCenter.Core.Repositories
{
    class ApiRepository : IApiRepository
    {
        private readonly IServiceCenterContextProvider _serviceCenterContextProvider;

        public ApiRepository(IServiceCenterContextProvider serviceCenterContextProvider)
        {
            _serviceCenterContextProvider = serviceCenterContextProvider;
        }

        public bool AddApi(ApiEntity api)
        {
            using (var context = _serviceCenterContextProvider.Provide())
            {
                context.Apis.Add(api);
                return context.SaveChanges() > 0;
            }
        }

        public bool DeleteApi(string code)
        {
            using (var context = _serviceCenterContextProvider.Provide())
            {
                var api = context.Apis.FirstOrDefault(s => s.Code == code);
                if (api == null)
                {
                    return true;
                }
                context.Apis.Remove(api);
                return context.SaveChanges() > 0;
            }
        }


        public bool Exist(string code)
        {
            using (var context = _serviceCenterContextProvider.Provide())
            {
                return context.Apis.Any(s => s.Code == code);
            }
        }


        public bool UpdateApi(ApiModel model)
        {
            using (var context = _serviceCenterContextProvider.Provide())
            {
                var api = context.Apis.FirstOrDefault(s => s.Code == model.Code);
                if (api == null)
                {
                    return false;
                }
                api.Description = model.Description;
                api.PublishTime = DateTime.Now;
                api.ServiceId = model.ServiceId;
                api.Url = model.Url;
                return context.SaveChanges() > 0;
            }
        }
    }
}
