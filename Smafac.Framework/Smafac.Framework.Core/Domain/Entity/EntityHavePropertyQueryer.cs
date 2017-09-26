using Smafac.Framework.Core.Models;
using Smafac.Framework.Core.Repositories.Property;
using Smafac.Framework.Core.Repositories.PropertyValue;
using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Domain.Entity
{
    public abstract class EntityHavePropertyQueryer<TEntity, TModel, TPageQueryModel, TPropertyValueModel, TPropertyEntity> : EntityQueryer<TEntity, TModel, TPageQueryModel>
                                                                            , IEntityHavePropertyQueryer<TModel, TPageQueryModel>
            where TEntity : SaasBaseEntity
            where TModel : SaasBaseModel
            where TPageQueryModel : PageQueryBaseModel
            where TPropertyValueModel : PropertyValueModel
            where TPropertyEntity : PropertyEntity
    {
        protected virtual bool IsLoadProperties
        {
            get
            {
                return true;
            }
        }

        public IPropertyValueSearchRepository<TPropertyValueModel> PropertyValueSearchRepository
        {
            get; protected set;
        }

        public IPropertySearchRepository<TPropertyEntity> PropertySearchRepository
        {
            get; protected set;
        }

        protected virtual void LoadProperties(IEnumerable<TModel> models)
        {
            var ids = models.Select(s => s.Id);
            var properties = PropertyValueSearchRepository.GetPropertyValues(UserContext.Current.SubscriberId, ids);
            models.ToList().ForEach(model =>
            {
                SetPropertyValues(model, properties.FirstOrDefault(s => s.Key == model.Id));
            });
        }

        protected abstract void SetPropertyValues(TModel model, IEnumerable<TPropertyValueModel> properties);

        protected virtual void LoadOthers(IEnumerable<TModel> models)
        {
            return;
        }

        protected override void WrapperModels(IEnumerable<TModel> models)
        {
            base.WrapperModels(models);
            if (!models.Any())
            {
                return;
            }
            if (IsLoadProperties)
            {
                LoadProperties(models);
            }
            LoadOthers(models);
        }

        protected virtual List<TPropertyValueModel> WrapperPropertyValues(IEnumerable<TPropertyValueModel> properties)
        {
            return properties == null ? new List<TPropertyValueModel>() : properties.ToList();
        }
    }
}
