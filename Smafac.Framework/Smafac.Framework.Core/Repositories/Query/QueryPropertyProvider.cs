using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Framework.Models;
using System.Reflection;

namespace Smafac.Framework.Core.Repositories.Query
{
    class QueryPropertyProvider : IQueryPropertyProvider
    {
        public List<QueryPropertyDescription> Provide(QueryBaseModel model)
        {
            return model.GetType().GetProperties()
                                 .Where(s => s.GetCustomAttribute<QueryPropertyAttribute>() != null)
                                 .Select(s => new QueryPropertyDescription(s))
                                 .ToList();
        }
    }
}
