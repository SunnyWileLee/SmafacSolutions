using Smafac.Framework.Core.Applications.Property;
using Smafac.Framework.Core.Domain;
using Smafac.Framework.Core.Models;
using Smafac.Framework.Core.Repositories.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Smafac.Framework.Core.Services.CustomizedColumn;

namespace Smafac.Framework.Core.Services.Property
{
    public abstract class PropertySearchService<TProperty, TPropertyModel> : CustomizedColumnSearchService<TProperty, TPropertyModel>,
        IPropertySearchService<TPropertyModel>
        where TProperty : PropertyEntity
        where TPropertyModel : PropertyModel
    {

    }
}
