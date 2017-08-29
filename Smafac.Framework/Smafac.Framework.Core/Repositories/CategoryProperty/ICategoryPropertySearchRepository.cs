using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Repositories.CategoryProperty
{
    public interface ICategoryPropertySearchRepository<TCategory, TProperty>
        where TCategory : CategoryEntity
        where TProperty : PropertyEntity
    {
        bool IsBound(Guid subscriberId, Guid categoryId);
        List<TProperty> GetProperties(Guid subscriberId, Guid categoryId);
    }
}
