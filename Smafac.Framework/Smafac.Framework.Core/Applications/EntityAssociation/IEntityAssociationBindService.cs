using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Applications.EntityAssociation
{
    public interface IEntityAssociationBindService
    {
        bool BindAssociations(Guid entityId, IEnumerable<Guid> associationIds);
    }
}
