using Smafac.Framework.Core.Applications;
using Smafac.Framework.Core.Applications.Property;
using Smafac.Framework.Core.Domain;
using Smafac.Framework.Core.Domain.Property;
using Smafac.Framework.Core.Models;
using Smafac.Framework.Core.Repositories.Property;
using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Services.Property
{
    public abstract class PropertyDeleteService<TPropertyEntity, TPropertyModel> : IPropertyDeleteService<TPropertyModel>
        where TPropertyEntity : PropertyEntity
        where TPropertyModel : PropertyModel
    {
        public virtual IEnumerable<IPropertyUsedChecker<TPropertyEntity>> PropertyUsedCheckers { get; protected set; }
        public virtual IPropertySearchRepository<TPropertyEntity> PropertySearchRepository { get; protected set; }

        public virtual IPropertyDeleteRepository<TPropertyEntity> PropertyDeleteRepository
        {
            get;
            protected set;
        }

        protected virtual bool AllowDeleteWhenUsed
        {
            get
            {
                return false;
            }
        }

        public virtual bool DeleteProperty(Guid propertyId)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var property = PropertySearchRepository.GetEntity(subscriberId, propertyId);
            if (!property.IsDeleteAssociations && PropertyUsedCheckers.Any(checker => checker.Check(property)))
            {
                return false;
            }
            return Delete(propertyId);
        }

        protected virtual bool Delete(Guid propertyId)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            return PropertyDeleteRepository.DeleteEntity(subscriberId, propertyId);
        }
    }
}
