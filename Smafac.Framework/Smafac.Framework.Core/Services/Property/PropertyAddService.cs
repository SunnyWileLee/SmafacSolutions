using Smafac.Framework.Core.Applications;
using Smafac.Framework.Core.Applications.Property;
using Smafac.Framework.Core.Domain;
using Smafac.Framework.Core.Models;
using Smafac.Framework.Core.Repositories.Property;
using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Smafac.Framework.Core.Domain.Property;
using Smafac.Framework.Core.Services.CustomizedColumn;

namespace Smafac.Framework.Core.Services.Property
{
    public abstract class PropertyAddService<TProperty, TPropertyModel> : CustomizedColumnAddService<TProperty, TPropertyModel>,
                    IPropertyAddService<TPropertyModel>
        where TProperty : PropertyEntity
        where TPropertyModel : PropertyModel
    {

    }
}
