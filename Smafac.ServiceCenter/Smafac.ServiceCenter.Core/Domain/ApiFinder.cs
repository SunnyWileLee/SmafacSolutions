using Smafac.Framework.Infrustructure;
using Smafac.ServiceCenter.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.ServiceCenter.Core.Domain
{
    class ApiFinder : ApiCacheFinder
    {
        private readonly IApiSearchRepository _apiSearchRepository;
        public ApiFinder(ICacher cacher, IApiSearchRepository apiSearchRepository)
            : base(cacher)
        {
            _apiSearchRepository = apiSearchRepository;
        }

        protected override ApiDescription FindApi(string code)
        {
            var entity = _apiSearchRepository.GetApiByCode(code);
            var api = new ApiDescription
            {
                ServiceId = entity.ServiceId,
                Code = entity.Code,
                Url = entity.Url
            };
            return api;
        }
    }
}
