using Smafac.Framework.Core.Applications.CategoryAssociation;
using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Applications.CategoryProperty
{
    public interface ICategoryPropertySearchService<TPropertyModel> : ICategoryAssociationSearchService<TPropertyModel>
        where TPropertyModel : PropertyModel
    {
        
    }
}
