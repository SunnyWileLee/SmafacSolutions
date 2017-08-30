using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Repositories.EntityAssociation
{
    public interface IEntityAssociationBindRepository<TCategory, TAssociation> : IEntityAssociationBindRepository<TCategory, TAssociation>
        where TCategory : SaasBaseEntity
        where TAssociation : SaasBaseEntity
    {

    }
}
