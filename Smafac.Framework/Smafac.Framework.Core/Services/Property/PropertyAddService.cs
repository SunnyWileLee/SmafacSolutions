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
    public abstract class PropertyAddService<TProperty, TPropertyModel> : IPropertyAddService<TPropertyModel>
        where TProperty : PropertyEntity
        where TPropertyModel : PropertyModel
    {
        public virtual IPropertySearchRepository<TProperty> PropertySearchRepository
        {

            get;
            protected set;
        }
        public virtual IPropertyAddRepository<TProperty> PropertyAddRepository
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

        public virtual bool AddProperty(TPropertyModel model)
        {
            if (!AllowRepeat && Exist(model.Name))
            {
                return false;
            }
            return Add(model);
        }

        protected virtual bool Exist(string name)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            return PropertySearchRepository.Any(subscriberId, name);
        }

        protected virtual bool Add(TPropertyModel model)
        {
            var property = Mapper.Map<TProperty>(model);
            property.SubscriberId = UserContext.Current.SubscriberId;
            return PropertyAddRepository.AddEntity(property);
        }
    }
}
