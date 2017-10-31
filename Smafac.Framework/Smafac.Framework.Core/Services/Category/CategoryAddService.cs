using AutoMapper;
using Smafac.Framework.Core.Applications.Category;
using Smafac.Framework.Core.Domain;
using Smafac.Framework.Core.Models;
using Smafac.Framework.Core.Repositories.Category;

namespace Smafac.Framework.Core.Services.Category
{
    public abstract class CategoryAddService<TCategory, TCategoryModel> : ICategoryAddService<TCategoryModel>
        where TCategory : CategoryEntity
        where TCategoryModel : CategoryModel
    {
        public virtual ICategorySearchRepository<TCategory> CategorySearchRepository
        {

            get;
            protected set;
        }
        public virtual ICategoryAddRepository<TCategory> CategoryAddRepository
        {
            get;
            protected set;
        }

        protected virtual bool AllowRepeat
        {
            get
            {
                return false;
            }
        }

        public virtual bool AddCategory(TCategoryModel model)
        {
            if (!AllowRepeat && Exist(model.Name))
            {
                return false;
            }
            return Add(model);
        }

        protected virtual bool Exist(string name)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            return CategorySearchRepository.Any(subscriberId, name);
        }

        protected virtual bool Add(TCategoryModel model)
        {
            var Category = Mapper.Map<TCategory>(model);
            Category.SubscriberId = UserContext.Current.SubscriberId;
            return CategoryAddRepository.AddEntity(Category);
        }
    }
}
