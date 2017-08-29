using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Applications.Property
{
    public interface IPropertySearchService<TPropertyModel> where TPropertyModel : PropertyModel
    {
        List<TPropertyModel> GetProperties();
        List<TPropertyModel> GetProperties(Guid entityId);
    }
}
