using Smafac.Framework.Core.Applications.CategoryProperty;
using Smafac.Framework.Core.Domain;
using Smafac.Framework.Core.Models;
using Smafac.Framework.Core.Repositories.CategoryProperty;
using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Smafac.Framework.Core.Services.CategoryProperty
{
    public abstract class CategoryPropertySearchService<TCategory, TProperty, TPropertyModel> : ICategoryPropertySearchService<TPropertyModel>
        where TCategory : CategoryEntity
        where TProperty : PropertyEntity
        where TPropertyModel : PropertyModel
    {
        public virtual ICategoryPropertySearchRepository<TCategory, TProperty> CategoryPropertySearchRepository
        {
            get; protected set;
        }

        public virtual ICategoryPropertyProvider<TProperty, TPropertyModel> CategoryPropertyProvider
        {
            get; protected set;
        }

        public List<TPropertyModel> GetProperties(Guid categoryId)
        {
            var properties = CategoryPropertySearchRepository.GetProperties(UserContext.Current.SubscriberId, categoryId);
            return Mapper.Map<List<TPropertyModel>>(properties);
        }

        public List<TPropertyModel> GetPropertiesIncludeParents(Guid categoryId)
        {
            var properties = CategoryPropertyProvider.ProvideProperties(categoryId);
            return properties;
        }
    }
}
