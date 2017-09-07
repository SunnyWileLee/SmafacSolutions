using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Domain.Triggers
{
    public interface ICategoryPropertyBindTrigger<TCategory, TProperty>
        where TCategory : CategoryEntity
        where TProperty : PropertyEntity
    {
        bool Bound(TCategory category, TProperty property);
    }
}
