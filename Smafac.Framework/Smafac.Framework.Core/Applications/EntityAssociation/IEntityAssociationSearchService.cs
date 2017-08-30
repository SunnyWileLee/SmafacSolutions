using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Applications.EntityAssociation
{
    public interface IEntityAssociationSearchService<TAssociation> where TAssociation : SaasBaseModel
    {
        List<TAssociation> GetAssociations(Guid entityId);
    }
}
