using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Repositories.Query
{
    public class QueryPropertyDescription
    {
        public QueryPropertyDescription(PropertyInfo property)
        {
            Property = property;
            Query = Property.GetCustomAttribute<QueryPropertyAttribute>();
            if (string.IsNullOrEmpty(Query.Name))
            {
                Query.Name = Property.Name;
            }
        }

        public PropertyInfo Property { get; private set; }
        public QueryPropertyAttribute Query { get; set; }
    }
}
