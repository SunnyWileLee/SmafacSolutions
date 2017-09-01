using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Applications.EntityAssociation
{
    public interface IEntityAssociationSearchService<TAssociationModel> where TAssociationModel : SaasBaseModel
    {
        List<TAssociationModel> GetAssociations(Guid entityId);
    }
}
