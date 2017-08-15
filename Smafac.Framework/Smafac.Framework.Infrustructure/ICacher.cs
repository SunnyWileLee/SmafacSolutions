using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Infrustructure
{
    public interface ICacher
    {
        void Set(string key, object value);
        TModel Get<TModel>(string key);
        void Remove(string key);
    }
}
