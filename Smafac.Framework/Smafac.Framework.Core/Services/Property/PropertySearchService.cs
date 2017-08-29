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
    public abstract class PropertySearchService<TProperty, TPropertyModel> : IPropertySearchService<TPropertyModel>
        where TProperty : PropertyEntity
        where TPropertyModel : PropertyModel
    {
        public virtual IPropertySearchRepository<TProperty> PropertySearchRepository
        {
            get;
            protected set;
        }

        public virtual List<TPropertyModel> GetProperties()
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var properties = PropertySearchRepository.GetEntities(subscriberId, s => true);
            return Mapper.Map<List<TPropertyModel>>(properties);
        }
        public abstract List<TPropertyModel> GetProperties(Guid entityId);
    }
}
