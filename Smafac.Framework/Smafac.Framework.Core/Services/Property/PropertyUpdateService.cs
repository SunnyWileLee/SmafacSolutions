using Smafac.Framework.Core.Applications;
using Smafac.Framework.Core.Applications.Property;
using Smafac.Framework.Core.Domain;
using Smafac.Framework.Core.Models;
using Smafac.Framework.Core.Repositories.Property;
using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Smafac.Framework.Core.Services.Property
{
    public abstract class PropertyUpdateService<TPropertyEntity, TPropertyModel> : IPropertyUpdateService<TPropertyModel>
        where TPropertyEntity : PropertyEntity
        where TPropertyModel : PropertyModel
    {

        public virtual IPropertyUpdateRepository<TPropertyEntity> PropertyUpdateRepository
        {
            get;
            protected set;
        }

        public virtual IPropertySearchRepository<TPropertyEntity> PropertySearchRepository
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

        public virtual bool UpdateProperty(TPropertyModel model)
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
            var properties = PropertySearchRepository.GetEntities(subscriberId, s => s.Name == name);
            return properties.Any(s => s.Id != id);
        }

        protected virtual bool Update(TPropertyModel model)
        {
            var propety = Mapper.Map<TPropertyEntity>(model);
            propety.SubscriberId = UserContext.Current.SubscriberId;
            return PropertyUpdateRepository.UpdateEntity(propety);
        }
    }
}
