using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Domain
{
    public abstract class CategoryPropertyProvider<TProperty> : ICategoryPropertyProvider<TProperty> where TProperty : PropertyEntity
    {
        public virtual List<TProperty> ProvideProperties(Guid categoryId)
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
            var properties = this.GetProperties(categoryId);
            if (category.IsRoot())
            {
                return properties.ToList();
            }
            return this.ProvideProperties(category.ParentId).Union(properties).Distinct(new PropertyIdComparer<TProperty>()).ToList();
        }

        protected abstract CategoryEntity GetCategory(Guid categoryId);

        protected abstract IEnumerable<TProperty> GetProperties(Guid categoryId);
    }
}
