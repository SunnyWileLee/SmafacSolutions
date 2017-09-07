using Smafac.Framework.Core.Domain.CategoryAssociation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Domain.CategoryProperty
{
    public interface ICategoryPropertyBindTrigger<TCategory, TProperty> : ICategoryAssociationBindTrigger<TCategory, TProperty>
        where TCategory : CategoryEntity
        where TProperty : PropertyEntity
    {

    }
}
