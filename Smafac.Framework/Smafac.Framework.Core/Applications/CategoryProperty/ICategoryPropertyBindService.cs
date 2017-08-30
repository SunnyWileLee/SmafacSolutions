using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Applications.CategoryProperty
{
    public interface ICategoryPropertyBindService
    {
        bool BindProperties(Guid categoryId, IEnumerable<Guid> propertyIds);
    }
}
