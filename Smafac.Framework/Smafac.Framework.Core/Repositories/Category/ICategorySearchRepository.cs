using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Repositories.Category
{
    public interface ICategorySearchRepository<TCategory> : IEntitySearchRepository<TCategory>
        where TCategory : CategoryEntity
    {
        bool Any(Guid subscriberId, string name);
        List<TCategory> GetCategories(Guid subscriberId, Guid parentId);
        bool Any(Guid subscriberId);
    }
}
