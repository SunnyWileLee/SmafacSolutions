using Smafac.ServiceCenter.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.ServiceCenter.Core.Repositories
{
    class ApiSearchRepository : IApiSearchRepository
    {
        private readonly IServiceCenterContextProvider _serviceCenterContextProvider;

        public ApiSearchRepository(IServiceCenterContextProvider serviceCenterContextProvider)
        {
            _serviceCenterContextProvider = serviceCenterContextProvider;
        }

        public ApiEntity GetApiByCode(string code)
        {
            using (var context = _serviceCenterContextProvider.Provide())
            {
                return context.Apis.FirstOrDefault(s => s.Code == code);
            }
        }
    }
}
