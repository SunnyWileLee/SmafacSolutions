using Smafac.Infrustructure.Config.Domain;
using Smafac.Infrustructure.Config.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Infrustructure.Config.Repositories
{
    interface IConfigSearchRepository
    {
        ConfigModel Get(string key, string module);
        List<ConfigModel> Get(Expression<Func<ConfigEntity, bool>> predicate);
    }
}
