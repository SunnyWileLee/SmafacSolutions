using Smafac.Framework.Core.Models;
using Smafac.Framework.Core.Repositories.PropertyValue;
using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
