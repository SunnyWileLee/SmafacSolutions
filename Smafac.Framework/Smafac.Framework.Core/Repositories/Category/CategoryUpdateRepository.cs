using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Repositories.Category
{
    public abstract class CategoryUpdateRepository<TContext, TCategory> : EntityUpdateRepository<TContext, TCategory>, ICategoryUpdateRepository<TCategory>
         where TCategory : CategoryEntity
         where TContext : DbContext
    {
        protected override void SetValue(TCategory entity, TCategory souce)
        {
            entity.Name = souce.Name;
        }
    }
}
