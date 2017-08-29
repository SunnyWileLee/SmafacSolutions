using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Applications.Property
{
    public interface IPropertyService<TPropertyModel>
        where TPropertyModel : PropertyModel
    {
        IPropertyAddService<TPropertyModel> AddService { get; }
        IPropertyDeleteService<TPropertyModel> DeleteService { get; }
        IPropertyUpdateService<TPropertyModel> UpdateService { get; }
        IPropertySearchService<TPropertyModel> SearchService { get; }
    }
}
