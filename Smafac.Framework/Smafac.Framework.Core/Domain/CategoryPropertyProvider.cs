using AutoMapper;
using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Framework.Core.Repositories.Category;
using Smafac.Framework.Core.Models;
using Smafac.Framework.Core.Repositories.CategoryProperty;

namespace Smafac.Framework.Core.Domain
{
    public abstract class CategoryPropertyProvider<TCategory, TProperty, TPropertyModel> : ICategoryPropertyProvider<TProperty, TPropertyModel>
        where TCategory : CategoryEntity
        where TProperty : PropertyEntity
        where TPropertyModel : PropertyModel
    {

        public virtual ICategorySearchRepository<TCategory> CategorySearchRepository
        {
            get; protected set;
        }

        public virtual ICategoryPropertySearchRepository<TCategory, TProperty> CategoryPropertySearchRepository
        {
            get; protected set;
        }

        public virtual List<TPropertyModel> ProvideProperties(Guid categoryId)
        {
            var propreties = this.GetProperties(categoryId);
            return Mapper.Map<List<TPropertyModel>>(propreties);
        }


        protected virtual CategoryEntity GetCategory(Guid categoryId)
        {
            return CategorySearchRepository.GetCategory(UserContext.Current.SubscriberId, categoryId);
        }

        protected virtual IEnumerable<TProperty> GetProperties(Guid categoryId)
        {
            if (categoryId == Guid.Empty)
            {
                return new List<TProperty>();
            }
            var category = this.GetCategory(categoryId);
            if (category == null)
            {
                return new List<TProperty>();
            }
            var properties = CategoryPropertySearchRepository.GetProperties(UserContext.Current.SubscriberId, categoryId);
            if (category.IsRoot())
            {
                return properties.ToList();
            }
            return this.GetProperties(category.ParentId).Union(properties).Distinct(new PropertyIdComparer<TProperty>()).ToList();
        }
    }
}
