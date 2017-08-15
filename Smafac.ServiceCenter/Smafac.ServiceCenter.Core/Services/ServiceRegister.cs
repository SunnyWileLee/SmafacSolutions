using Smafac.ServiceCenter.Core.Applications;
using Smafac.ServiceCenter.Core.Repositories;
using Smafac.ServiceCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Smafac.ServiceCenter.Core.Domain;

namespace Smafac.ServiceCenter.Core.Services
{
    class ServiceRegister : IServiceRegister
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IApiRepository _apiRepository;
        private readonly IServiceSearchRepository _serviceSearchRepository;
        public ServiceRegister(IServiceRepository serviceRepository,
                                IApiRepository apiRepository,
            IServiceSearchRepository serviceSearchRepository)
        {
            _serviceRepository = serviceRepository;
            _apiRepository = apiRepository;
            _serviceSearchRepository = serviceSearchRepository;
        }

        public bool Register(ServiceModel serviceModel, IEnumerable<ApiModel> apis)
        {
            var service = RegisterService(serviceModel);
            if (service == null)
            {
                return false;
            }
            foreach (var api in apis)
            {
                api.ServiceId = service.Id;
                RegisterApi(api);
            }
            return true;
        }

        protected bool RegisterApi(ApiModel model)
        {
            if (_apiRepository.Exist(model.Code))
            {
                return _apiRepository.UpdateApi(model);
            }
            else
            {
                var api = new ApiEntity
                {
                    Code = model.Code,
                    ServiceId = model.ServiceId,
                    Description = model.Description,
                    PublishTime = DateTime.Now,
                    Url = model.Url
                };
                return _apiRepository.AddApi(api);
            }
        }

        protected ServiceEntity RegisterService(ServiceModel model)
        {
            if (_serviceRepository.ExistService(model.Name))
            {
                var update = _serviceRepository.UpdateService(model);
                if (update)
                {
                    return _serviceSearchRepository.GetServiceByName(model.Name);
                }
                return null;
            }
            else
            {
                var service = Mapper.Map<ServiceEntity>(model);
                var add = _serviceRepository.AddService(service);
                if (add)
                {
                    return service;
                }
                return null;
            }
        }
    }
}
