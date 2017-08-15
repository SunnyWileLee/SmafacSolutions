using Smafac.Framework.Core.Models;
using Smafac.Framework.Infrustructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.ServiceCenter.Core.Domain
{
     abstract class ApiCacheFinder : IApiFinder
    {
        public const string CachePrefix = "apidescription";
        private readonly ICacher _cacher;
        public ApiCacheFinder(ICacher cacher)
        {
            _cacher = cacher;
        }

        public virtual ApiDescription Find(string code)
        {
            var key = CreateCacheKey(code);
            var api = _cacher.Get<ApiDescription>(key);
            if (api != null)
            {
                return api;
            }
            api = FindApi(code);
            if (api == null)
            {
                throw new Exception("api不存在");
            }
            _cacher.Set(key, api);
            return api;
        }

        protected abstract ApiDescription FindApi(string code);

        protected virtual string CreateCacheKey(string code)
        {
            return string.Format("{0}_{1}", CachePrefix, code);
        }
    }
}
