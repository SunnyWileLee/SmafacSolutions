using Smafac.Framework.Core.Applications;
using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Services
{
    public abstract class PropertyUpdateService<TPropertyModel> : IPropertyUpdateService<TPropertyModel> where TPropertyModel : PropertyModel
    {
        protected virtual bool AllowRepeat
        {
            get
            {
                return false;
            }
        }

        public virtual bool UpdateProperty(TPropertyModel model)
        {
            if (!AllowRepeat && Exist())
            {
                return false;
            }
            return Update(model);
        }

        protected abstract bool Exist();

        protected abstract bool Update(TPropertyModel model);
    }
}
