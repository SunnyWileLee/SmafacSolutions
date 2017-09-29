using Smafac.Framework.Core.Applications;
using Smafac.Framework.Core.Applications.CustomizedColumn;
using Smafac.Framework.Core.Domain;
using Smafac.Framework.Core.Domain.CustomizedColumn;
using Smafac.Framework.Core.Models;
using Smafac.Framework.Core.Repositories.CustomizedColumn;
using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Services.CustomizedColumn
{
    public abstract class CustomizedColumnDeleteService<TCustomizedColumn, TCustomizedColumnModel> : ICustomizedColumnDeleteService<TCustomizedColumnModel>
        where TCustomizedColumn : CustomizedColumnEntity
        where TCustomizedColumnModel : CustomizedColumnModel
    {
        public virtual IEnumerable<ICustomizedColumnUsedChecker<TCustomizedColumn>> CustomizedColumnUsedCheckers { get; protected set; }
        public virtual IEnumerable<ICustomizedColumnDeleteTrigger<TCustomizedColumn>> CustomizedColumnDeleteTriggers { get; set; }
        public virtual ICustomizedColumnSearchRepository<TCustomizedColumn> CustomizedColumnSearchRepository { get; protected set; }

        public virtual ICustomizedColumnDeleteRepository<TCustomizedColumn> CustomizedColumnDeleteRepository
        {
            get;
            protected set;
        }

        protected virtual bool AllowDeleteWhenUsed
        {
            get
            {
                return false;
            }
        }

        public virtual bool DeleteColumn(Guid propertyId)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var property = CustomizedColumnSearchRepository.GetEntity(subscriberId, propertyId);
            if (!property.IsDeleteAssociations && CustomizedColumnUsedCheckers.Any(checker => checker.Check(property)))
            {
                return false;
            }
            var result = Delete(propertyId);
            if (result && CustomizedColumnDeleteTriggers != null)
            {
                CustomizedColumnDeleteTriggers.ToList().ForEach(trigger =>
                {
                    result &= trigger.Deleted(property);
                });
            }
            return result;
        }

        protected virtual bool Delete(Guid propertyId)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            return CustomizedColumnDeleteRepository.DeleteEntity(subscriberId, propertyId);
        }
    }
}
