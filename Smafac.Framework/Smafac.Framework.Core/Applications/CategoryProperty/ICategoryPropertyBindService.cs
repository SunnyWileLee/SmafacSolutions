using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Applications.CategoryProperty
{
    public interface ICategoryPropertyBindService<TCategory, TProperty>
        where TCategory : CategoryEntity
        where TProperty : PropertyEntity
    {
        bool BindProperties(Guid categoryId, IEnumerable<Guid> propertyIds);
    }
}
