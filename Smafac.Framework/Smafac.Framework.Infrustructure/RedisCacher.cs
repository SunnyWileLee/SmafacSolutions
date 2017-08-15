using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Infrustructure
{
    class RedisCacher //: ICacher
    {
        public void Set(string key, object value)
        {
            throw new NotImplementedException();
        }

        public TModel Get<TModel>(string key)
        {
            throw new NotImplementedException();
        }
    }
}
