using Smafac.Framework.Core.Applications.Category;
using Smafac.Framework.Core.Domain;
using Smafac.Framework.Core.Models;
using Smafac.Framework.Core.Repositories.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Services.Category
{
    public abstract class CategoryInitialization<TCategory> : ICategoryInitialization<TCategory>
         where TCategory : CategoryEntity
    {
        public virtual ICategoryAddRepository<TCategory> CategoryAddRepository { get; protected set; }

        public virtual ICategorySearchRepository<TCategory> CategorySearchRepository { get; protected set; }

        public virtual void Init(Guid subscriberId)
        {
            if (CategorySearchRepository.Any(subscriberId))
            {
                return;
            }
            var category = CreateDefaultCategory(subscriberId);
            CategoryAddRepository.AddEntity(category);
        }

        protected virtual TCategory CreateDefaultCategory(Guid subscriberId)
        {
            var category = Activator.CreateInstance<TCategory>();
            category.Name = "默认分类";
            category.SubscriberId = subscriberId;
            return category;
        }
    }
}
