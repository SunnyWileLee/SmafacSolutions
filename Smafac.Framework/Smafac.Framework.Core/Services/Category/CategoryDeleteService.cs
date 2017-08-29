using Smafac.Framework.Core.Applications;
using Smafac.Framework.Core.Applications.Category;
using Smafac.Framework.Core.Domain;
using Smafac.Framework.Core.Models;
using Smafac.Framework.Core.Repositories.Category;
using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Services.Category
{
    public abstract class CategoryDeleteService<TCategoryEntity, TCategoryModel> : ICategoryDeleteService<TCategoryModel>
        where TCategoryEntity : CategoryEntity
        where TCategoryModel : CategoryModel
    {

        public virtual ICategoryDeleteRepository<TCategoryEntity> CategoryDeleteRepository
        {
            get;
            protected set;
        }

        protected virtual bool AllowDeleteWhenUsed
        {
            get
            {
                return false;
            }
        }

        public virtual bool DeleteCategory(Guid CategoryId)
        {
            if (!AllowDeleteWhenUsed && IsUsed(CategoryId))
            {
                return false;
            }
            return Delete(CategoryId);
        }

        protected abstract bool IsUsed(Guid CategoryId);

        protected virtual bool Delete(Guid CategoryId)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            return CategoryDeleteRepository.DeleteEntity(subscriberId, CategoryId);
        }
    }
}
