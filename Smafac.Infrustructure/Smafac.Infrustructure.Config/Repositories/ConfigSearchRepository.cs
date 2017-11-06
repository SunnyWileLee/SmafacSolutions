using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Smafac.Infrustructure.Config.Domain;
using Smafac.Infrustructure.Config.Models;
using AutoMapper;

namespace Smafac.Infrustructure.Config.Repositories
{
    class ConfigSearchRepository : IConfigSearchRepository
    {
        private readonly IConfigContextProvider _contextProvider;

        public ConfigSearchRepository(IConfigContextProvider contextProvider)
        {
            _contextProvider = contextProvider;
        }

        public ConfigModel Get(string key, string module)
        {
            using (var context = _contextProvider.Provide())
            {
                var config = context.Configs.FirstOrDefault(s => s.Key == key && s.Module == module);
                if (config == null)
                {
                    return null;
                }
                return Mapper.Map<ConfigModel>(config);
            }
        }

        public List<ConfigModel> Get(Expression<Func<ConfigEntity, bool>> predicate)
        {
            using (var context = _contextProvider.Provide())
            {
                var configs = context.Configs.Where(predicate).ToList();
                return Mapper.Map<List<ConfigModel>>(configs);
            }
        }
    }
}
