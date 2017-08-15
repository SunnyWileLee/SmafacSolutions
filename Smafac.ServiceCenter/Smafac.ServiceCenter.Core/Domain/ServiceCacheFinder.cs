using Smafac.Framework.Infrustructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.ServiceCenter.Core.Domain
{
    abstract class ServiceCacheFinder : IServiceFinder
    {
        public const string CachePrefix = "ServiceDescription";
        private readonly ICacher _cacher;
        public ServiceCacheFinder(ICacher cacher)
        {
            _cacher = cacher;
        }

        public ServiceDescription Find(Guid id)
        {
            var key = CreateCacheKey(id);
            var service = _cacher.Get<ServiceDescription>(key);
            if (service != null)
            {
                return service;
            }
            service = FindService(id);
            if (service == null)
            {
                throw new Exception("api不存在");
            }
            _cacher.Set(key, service);
            return service;
        }

        protected abstract ServiceDescription FindService(Guid id);

        protected virtual string CreateCacheKey(Guid id)
        {
            return string.Format("{0}_{1}", CachePrefix, id.ToString().ToUpper().Replace("-", string.Empty));
        }
    }
}
