using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Repositories.CategoryProperty
{
    public interface ICategoryPropertyBindRepository<TCategory, TProperty>
        where TCategory : CategoryEntity
        where TProperty : PropertyEntity
    {
        bool BindProperties(Guid subscriberId, Guid categoryId, IEnumerable<Guid> propertyIds);
        bool UnbindProperties(Guid subscriberId, Guid categoryId);
    }
}
