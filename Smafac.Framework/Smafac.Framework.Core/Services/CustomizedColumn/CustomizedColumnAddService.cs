using Smafac.Framework.Core.Applications;
using Smafac.Framework.Core.Applications.CustomizedColumn;
using Smafac.Framework.Core.Domain;
using Smafac.Framework.Core.Models;
using Smafac.Framework.Core.Repositories.CustomizedColumn;
using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Smafac.Framework.Core.Domain.CustomizedColumn;

namespace Smafac.Framework.Core.Services.CustomizedColumn
{
    public abstract class CustomizedColumnAddService<TCustomizedColumn, TCustomizedColumnModel> : ICustomizedColumnAddService<TCustomizedColumnModel>
        where TCustomizedColumn : CustomizedColumnEntity
        where TCustomizedColumnModel : CustomizedColumnModel
    {
        public virtual IEnumerable<ICustomizedColumnAddTrigger<TCustomizedColumn>> CustomizedColumnAddTriggers { get; set; }

        public virtual ICustomizedColumnSearchRepository<TCustomizedColumn> CustomizedColumnSearchRepository
        {

            get;
            protected set;
        }
        public virtual ICustomizedColumnAddRepository<TCustomizedColumn> CustomizedColumnAddRepository
        {
            get;
            protected set;
        }

        protected virtual bool AllowRepeat
        {
            get
            {
                return false;
            }
        }

        public virtual bool AddColumn(TCustomizedColumnModel model)
        {
            if (!AllowRepeat && Exist(model.Name))
            {
                return false;
            }
            return Add(model);
        }

        protected virtual bool Exist(string name)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            return CustomizedColumnSearchRepository.Any(subscriberId, name);
        }

        protected virtual bool Add(TCustomizedColumnModel model)
        {
            var property = Mapper.Map<TCustomizedColumn>(model);
            property.SubscriberId = UserContext.Current.SubscriberId;
            var add = CustomizedColumnAddRepository.AddEntity(property);
            if (add && CustomizedColumnAddTriggers != null)
            {
                CustomizedColumnAddTriggers.ToList().ForEach(trigger =>
                {
                    add &= trigger.Added(property);
                });
            }
            return add;
        }
    }
}
