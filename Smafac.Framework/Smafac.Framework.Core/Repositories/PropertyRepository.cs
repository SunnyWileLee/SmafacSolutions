using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Repositories
{
    public abstract class PropertyRepository<TDbContext, TProperty> : IPropertyRepository<TProperty>
        where TProperty : PropertyEntity
        where TDbContext : DbContext
    {
        public virtual IDbContextProvider<TDbContext> ContextProvider { get; protected set; }

        public virtual bool AddProperty(TProperty property)
        {
            using (var context = ContextProvider.Provide())
            {
                context.Set<TProperty>().Add(property);
                return context.SaveChanges() > 0;
            }
        }

        public virtual bool Any(Guid subscriberId, string name)
        {
            using (var context = ContextProvider.Provide())
            {
                return context.Set<TProperty>().Any(s => s.SubscriberId == subscriberId && s.Name.Equals(name));
            }
        }

        public virtual bool DeleteProperty(Guid subscriberId, Guid propertyId)
        {
            using (var context = ContextProvider.Provide())
            {
                var properties = context.Set<TProperty>();
                var property = properties.FirstOrDefault(s => s.SubscriberId == subscriberId && s.Id == propertyId);
                if (property == null)
                {
                    return true;
                }
                properties.Remove(property);
                return context.SaveChanges() > 0;
            }
        }

        public virtual List<TProperty> GetProperties(Guid subscriberId)
        {
            using (var context = ContextProvider.Provide())
            {
                var properties = context.Set<TProperty>();
                return properties.Where(s => s.SubscriberId == subscriberId).ToList();
            }
        }

        public virtual bool UpdateProperty(TProperty property)
        {
            using (var context = ContextProvider.Provide())
            {
                var properties = context.Set<TProperty>();
                var entity = properties.FirstOrDefault(s => s.SubscriberId == property.SubscriberId && s.Id == property.Id);
                if (entity == null)
                {
                    return false;
                }
                entity.Name = property.Name;
                return context.SaveChanges() > 0;
            }
        }
    }
}
