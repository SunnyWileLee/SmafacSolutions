using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Smafac.Framework.Infrustructure
{
    class DictionaryCacher : ICacher
    {
        public static Dictionary<string, string> _caches = new Dictionary<string, string>();

        public void Set(string key, object value)
        {
            if (_caches.ContainsKey(key))
            {
                _caches[key] = JsonConvert.SerializeObject(value);
            }
            else
            {
                _caches.Add(key, JsonConvert.SerializeObject(value));
            }
        }

        public TModel Get<TModel>(string key)
        {
            if (!_caches.ContainsKey(key))
            {
                return default(TModel);
            }
            var value = _caches[key];
            return JsonConvert.DeserializeObject<TModel>(value);
        }


        public void Remove(string key)
        {
            if (!_caches.ContainsKey(key))
            {
                return;
            }
            _caches.Remove(key);
        }
    }
}
