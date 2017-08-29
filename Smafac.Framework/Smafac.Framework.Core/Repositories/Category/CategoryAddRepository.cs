using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Repositories.Category
{
    public abstract class CategoryAddRepository<TContext, TCategory> : EntityAddRepository<TContext, TCategory>, ICategoryAddRepository<TCategory>
         where TCategory : CategoryEntity
         where TContext : DbContext
    {

    }
}
