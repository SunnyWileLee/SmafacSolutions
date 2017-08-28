using Smafac.Framework.Core.Applications;
using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Services
{
    public abstract class PropertyAddService<TPropertyModel> : IPropertyAddService<TPropertyModel> where TPropertyModel : PropertyModel
    {
        protected virtual bool AllowRepeat
        {
            get
            {
                return false;
            }
        }

        public virtual bool AddProperty(TPropertyModel model)
        {
            if (!AllowRepeat && Exist())
            {
                return false;
            }
            return Add(model);
        }

        protected abstract bool Exist();

        protected abstract bool Add(TPropertyModel model);
    }
}
