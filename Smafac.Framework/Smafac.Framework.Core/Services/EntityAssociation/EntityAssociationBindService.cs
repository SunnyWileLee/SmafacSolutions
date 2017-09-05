using Smafac.Framework.Core.Applications.EntityAssociation;
using Smafac.Framework.Core.Domain;
using Smafac.Framework.Core.Models;
using Smafac.Framework.Core.Repositories.EntityAssociation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Services.EntityAssociation
{
    public abstract class EntityAssociationBindService<TEntity, TAssociation> : IEntityAssociationBindService
        where TEntity : SaasBaseEntity
        where TAssociation : SaasBaseEntity
    {

        protected virtual bool AllowCover
        {
            get
            {
                return true;
            }
        }

        public virtual IEntityAssociationBindRepository<TEntity, TAssociation> EntityAssociationBindRepository
        {
            get;
            protected set;
        }

        public virtual IEntityAssociationSearchRepository<TEntity, TAssociation> EntityAssociationSearchRepository
        {
            get;
            protected set;
        }

        public bool BindAssociations(Guid entityId, IEnumerable<Guid> associationIds)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            if (EntityAssociationSearchRepository.IsBound(subscriberId, entityId))
            {
                if (!AllowCover)
                {
                    return false;
                }
                if (!EntityAssociationBindRepository.UnbindEntity(subscriberId, entityId))
                {
                    return false;
                }
            }
            return EntityAssociationBindRepository.BindEntity(subscriberId, entityId, associationIds);
        }
    }
}
