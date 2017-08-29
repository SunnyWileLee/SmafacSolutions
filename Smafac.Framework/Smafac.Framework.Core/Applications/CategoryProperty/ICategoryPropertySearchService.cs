using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Applications.CategoryProperty
{
    public interface ICategoryPropertySearchService<TPropertyModel> where TPropertyModel : PropertyModel
    {
        List<TPropertyModel> GetPropertiesIncludeParents(Guid categoryId);
        List<TPropertyModel> GetProperties(Guid categoryId);
    }
}
