using Smafac.Framework.Core.Domain.CategoryAssociation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Domain.CategoryProperty
{
    public abstract class CategoryPropertyBindTrigger<TEntity, TCategory, TProperty, TPropertyValue> : CategoryAssociationBindTrigger<TEntity, TCategory, TProperty, TPropertyValue>,
                                                    ICategoryPropertyBindTrigger<TCategory, TProperty>
            where TCategory : CategoryEntity
            where TProperty : PropertyEntity
            where TEntity : SaasBaseEntity
            where TPropertyValue : PropertyValueEntity
    {
        protected override void ModifyValue(TPropertyValue value, Guid entityId, TProperty property)
        {
            base.ModifyValue(value, entityId, property);
            value.PropertyId = property.Id;
            value.Value = string.Empty;
        }
    }
}
