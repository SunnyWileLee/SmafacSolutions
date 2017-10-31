using Smafac.Framework.Core.Models;
using Smafac.Framework.Core.Repositories.PropertyValue;

namespace Smafac.Framework.Core.Domain.Property
{
    public abstract class PropertyUsedByValueChecker<TProperty, TPropertyValueModel> : IPropertyUsedChecker<TProperty>
         where TProperty : PropertyEntity
        where TPropertyValueModel : PropertyValueModel
    {
        public IPropertyValueSearchRepository<TPropertyValueModel> PropertyValueSearchRepository { get; protected set; }

        public virtual bool Check(TProperty column)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            return PropertyValueSearchRepository.Any(subscriberId, column.Id);
        }
    }
}
