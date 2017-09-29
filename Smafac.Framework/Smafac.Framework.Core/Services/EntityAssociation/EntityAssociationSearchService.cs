using AutoMapper;
using Smafac.Framework.Core.Applications.EntityAssociation;
using Smafac.Framework.Core.Domain;
using Smafac.Framework.Core.Models;
using Smafac.Framework.Core.Repositories.EntityAssociation;
using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Services.EntityAssociation
{
    public abstract class EntityAssociationSearchService<TEntity, TAssociation, TAssociationModel>
                        : IEntityAssociationSearchService<TAssociationModel>
        where TEntity : SaasBaseEntity
        where TAssociation : SaasBaseEntity
        where TAssociationModel : SaasBaseModel
    {
        public virtual IEntityAssociationSearchRepository<TEntity, TAssociation> EntityAssociationSearchRepository
        {
            get; protected set;
        }

        public virtual List<TAssociationModel> GetAssociations(Guid entityId)
        {
            var associations = EntityAssociationSearchRepository.GetAssociations(UserContext.Current.SubscriberId, entityId);
            return Mapper.Map<List<TAssociationModel>>(associations);
        }
    }
}
