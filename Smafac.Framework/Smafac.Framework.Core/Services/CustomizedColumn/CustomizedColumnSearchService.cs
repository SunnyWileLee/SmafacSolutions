using AutoMapper;
using Smafac.Framework.Core.Applications.CustomizedColumn;
using Smafac.Framework.Core.Domain.CustomizedColumn;
using Smafac.Framework.Core.Models;
using Smafac.Framework.Core.Repositories.CustomizedColumn;
using System;
using System.Collections.Generic;

namespace Smafac.Framework.Core.Services.CustomizedColumn
{
    public abstract class CustomizedColumnSearchService<TCustomizedColumn, TCustomizedColumnModel> : ICustomizedColumnSearchService<TCustomizedColumnModel>
        where TCustomizedColumn : CustomizedColumnEntity
        where TCustomizedColumnModel : CustomizedColumnModel
    {
        public virtual ICustomizedColumnSearchRepository<TCustomizedColumn> CustomizedColumnSearchRepository
        {
            get;
            protected set;
        }

        public virtual TCustomizedColumnModel GetColumn(Guid id)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var property = CustomizedColumnSearchRepository.GetEntity(subscriberId, id);
            return Mapper.Map<TCustomizedColumnModel>(property);
        }

        public virtual List<TCustomizedColumnModel> GetColumns()
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var properties = CustomizedColumnSearchRepository.GetEntities(subscriberId, s => true);
            return Mapper.Map<List<TCustomizedColumnModel>>(properties);
        }
        public abstract List<TCustomizedColumnModel> GetColumns(Guid entityId);
    }
}
