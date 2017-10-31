using AutoMapper;
using Smafac.Framework.Core.Applications.CustomizedColumn;
using Smafac.Framework.Core.Domain.CustomizedColumn;
using Smafac.Framework.Core.Models;
using Smafac.Framework.Core.Repositories.CustomizedColumn;
using System;
using System.Linq;

namespace Smafac.Framework.Core.Services.CustomizedColumn
{
    public abstract class CustomizedColumnUpdateService<TCustomizedColumnEntity, TCustomizedColumnModel> : ICustomizedColumnUpdateService<TCustomizedColumnModel>
        where TCustomizedColumnEntity : CustomizedColumnEntity
        where TCustomizedColumnModel : CustomizedColumnModel
    {

        public virtual ICustomizedColumnUpdateRepository<TCustomizedColumnEntity> CustomizedColumnUpdateRepository
        {
            get;
            protected set;
        }

        public virtual ICustomizedColumnSearchRepository<TCustomizedColumnEntity> CustomizedColumnSearchRepository
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

        public virtual bool UpdateColumn(TCustomizedColumnModel model)
        {
            if (!AllowRepeat && Exist(model.Id, model.Name))
            {
                return false;
            }
            return Update(model);
        }

        protected virtual bool Exist(Guid id, string name)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var properties = CustomizedColumnSearchRepository.GetEntities(subscriberId, s => s.Name == name);
            return properties.Any(s => s.Id != id);
        }

        protected virtual bool Update(TCustomizedColumnModel model)
        {
            var propety = Mapper.Map<TCustomizedColumnEntity>(model);
            propety.SubscriberId = UserContext.Current.SubscriberId;
            return CustomizedColumnUpdateRepository.UpdateEntity(propety);
        }
    }
}
