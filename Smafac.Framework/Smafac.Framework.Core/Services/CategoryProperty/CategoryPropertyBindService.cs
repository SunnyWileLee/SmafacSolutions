using Smafac.Framework.Core.Applications.CategoryProperty;
using Smafac.Framework.Core.Domain;
using Smafac.Framework.Core.Models;
using Smafac.Framework.Core.Repositories.CategoryProperty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Services.CategoryProperty
{
    public abstract class CategoryPropertyBindService<TCategory, TProperty> : ICategoryPropertyBindService<TCategory, TProperty>
        where TCategory : CategoryEntity
        where TProperty : PropertyEntity
    {
        protected virtual bool AllowCover
        {
            get
            {
                return true;
            }
        }

        public ICategoryPropertyBindRepository<TCategory, TProperty> CategoryPropertyBindRepository
        {
            get;
            protected set;
        }

        public ICategoryPropertySearchRepository<TCategory, TProperty> CategoryPropertySearchRepository
        {
            get;
            protected set;
        }

        public virtual bool BindProperties(Guid categoryId, IEnumerable<Guid> propertyIds)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            if (CategoryPropertySearchRepository.IsBound(subscriberId, categoryId))
            {
                if (!AllowCover)
                {
                    return false;
                }
                if (!CategoryPropertyBindRepository.UnbindProperties(subscriberId, categoryId))
                {
                    return false;
                }
            }
            return CategoryPropertyBindRepository.BindProperties(subscriberId, categoryId, propertyIds);
        }
    }
}
