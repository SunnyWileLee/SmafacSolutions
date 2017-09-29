using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Repositories.Query
{
    public interface IQueryPropertyProvider
    {
        List<QueryPropertyDescription> Provide(QueryBaseModel model);
    }
}
