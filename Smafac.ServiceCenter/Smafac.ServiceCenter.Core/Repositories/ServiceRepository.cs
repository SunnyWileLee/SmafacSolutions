using Smafac.ServiceCenter.Core.Domain;
using Smafac.ServiceCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.ServiceCenter.Core.Repositories
{
    class ServiceRepository : IServiceRepository
    {

        private readonly IServiceCenterContextProvider _serviceCenterContextProvider;

        public ServiceRepository(IServiceCenterContextProvider serviceCenterContextProvider)
        {
            _serviceCenterContextProvider = serviceCenterContextProvider;
        }

        public bool AddService(ServiceEntity service)
        {
            using (var context = _serviceCenterContextProvider.Provide())
            {
                context.Services.Add(service);
                return context.SaveChanges() > 0;
            }
        }

        public bool DeleteService(string name)
        {
            using (var context = _serviceCenterContextProvider.Provide())
            {
                var service = context.Services.FirstOrDefault(s => s.Name == name);
                if (service == null)
                {
                    return true;
                }
                context.Services.Remove(service);
                return context.SaveChanges() > 0;
            }
        }

        public bool ExistService(string name)
        {
            using (var context = _serviceCenterContextProvider.Provide())
            {
                return context.Services.Any(s => s.Name == name);
            }
        }


        public bool UpdateService(ServiceModel model)
        {
            using (var context = _serviceCenterContextProvider.Provide())
            {
                var service = context.Services.FirstOrDefault(s => s.Name == model.Name);
                if (service == null)
                {
                    return false;
                }
                service.Descrtiption = model.Descrtiption;
                service.Domain = model.Domain;
                service.PublishTime = DateTime.Now;
                return context.SaveChanges() > 0;
            }
        }
    }
}
