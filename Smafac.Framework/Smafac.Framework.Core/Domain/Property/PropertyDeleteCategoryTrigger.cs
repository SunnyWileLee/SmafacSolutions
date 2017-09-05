using Smafac.Framework.Core.Models;
using Smafac.Framework.Core.Repositories.CategoryProperty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Domain.Property
{
    public abstract class PropertyDeleteCategoryTrigger<TCategory, TProperty, TCategoryProperty> : IPropertyDeleteTrigger<TProperty>
            where TCategory : CategoryEntity
            where TProperty : PropertyEntity
            where TCategoryProperty : CategoryPropertyEntity
    {
        public virtual ICategoryPropertyBindRepository<TCategory, TProperty> CategoryPropertyBindRepository
        {
            get; protected set;
        }

        public virtual bool Deleted(TProperty entity)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            if (subscriberId != entity.SubscriberId)
            {
                return false;
            }
            return CategoryPropertyBindRepository.UnbindAssociation(subscriberId, entity.Id);
        }
    }
}
