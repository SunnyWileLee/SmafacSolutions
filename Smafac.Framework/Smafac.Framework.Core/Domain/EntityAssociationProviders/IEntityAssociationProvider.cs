using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Domain.EntityAssociationProviders
{
    public interface IEntityAssociationProvider<TAssociationModel>
        where TAssociationModel : SaasBaseModel
    {
        List<TAssociationModel> ProvideAssociations(Guid entityId);
    }
}
