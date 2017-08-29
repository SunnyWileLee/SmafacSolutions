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
using AutoMapper;

namespace Smafac.Framework.Core.Services.Category
{
    public abstract class CategoryUpdateService<TCategoryEntity, TCategoryModel> : ICategoryUpdateService<TCategoryModel>
        where TCategoryEntity : CategoryEntity
        where TCategoryModel : CategoryModel
    {

        public virtual ICategoryUpdateRepository<TCategoryEntity> CategoryUpdateRepository
        {
            get;
            protected set;
        }

        public virtual ICategorySearchRepository<TCategoryEntity> CategorySearchRepository
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

        public virtual bool UpdateCategory(TCategoryModel model)
        {
            if (!AllowRepeat && Exist(model.Id, model.Name))
            {
                return false;
            }
            return Update(model);
        }

        protected virtual bool Exist(Guid id, string name)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var properties = CategorySearchRepository.GetEntities(subscriberId, s => s.Name == name);
            return properties.Any(s => s.Id != id);
        }

        protected virtual bool Update(TCategoryModel model)
        {
            var propety = Mapper.Map<TCategoryEntity>(model);
            propety.SubscriberId = UserContext.Current.SubscriberId;
            return CategoryUpdateRepository.UpdateEntity(propety);
        }
    }
}
