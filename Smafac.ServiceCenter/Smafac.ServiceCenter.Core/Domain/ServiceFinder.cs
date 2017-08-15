using Smafac.Framework.Infrustructure;
using Smafac.ServiceCenter.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.ServiceCenter.Core.Domain
{
    class ServiceFinder : ServiceCacheFinder
    {
        private readonly IServiceSearchRepository _serviceSearchRepository;

        public ServiceFinder(ICacher cacher, IServiceSearchRepository serviceSearchRepository)
            : base(cacher)
        {
            _serviceSearchRepository = serviceSearchRepository;
        }

        protected override ServiceDescription FindService(Guid id)
        {
            var entity = _serviceSearchRepository.GetServiceById(id);
            return new ServiceDescription
            {
                Domain = entity.Domain,
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}
