using Smafac.ServiceCenter.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.ServiceCenter.Core.Repositories
{
    class ServiceSearchRepository : IServiceSearchRepository
    {
        private readonly IServiceCenterContextProvider _serviceCenterContextProvider;

        public ServiceSearchRepository(IServiceCenterContextProvider serviceCenterContextProvider)
        {
            _serviceCenterContextProvider = serviceCenterContextProvider;
        }

        public ServiceEntity GetServiceById(Guid id)
        {
            using (var context = _serviceCenterContextProvider.Provide())
            {
                var service = context.Services.FirstOrDefault(s => s.Id == id);
                return service;
            }
        }


        public ServiceEntity GetServiceByName(string name)
        {
            using (var context = _serviceCenterContextProvider.Provide())
            {
                var service = context.Services.FirstOrDefault(s => s.Name == name);
                return service;
            }
        }
    }
}
