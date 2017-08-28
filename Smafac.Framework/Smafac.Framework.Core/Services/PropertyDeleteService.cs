using Smafac.Framework.Core.Applications;
using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Services
{
    public abstract class PropertyDeleteService<TPropertyModel> : IPropertyDeleteService<TPropertyModel> where TPropertyModel : PropertyModel
    {
        protected virtual bool AllowDeleteWhenUsed
        {
            get
            {
                return false;
            }
        }

        public virtual bool DeleteProperty(Guid propertyId)
        {
            if (!AllowDeleteWhenUsed && IsUsed(propertyId))
            {
                return false;
            }
            return Delete(propertyId);
        }

        protected abstract bool IsUsed(Guid propertyId);

        protected abstract bool Delete(Guid propertyId);
    }
}
