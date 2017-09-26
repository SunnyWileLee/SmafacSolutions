using AutoMapper;
using Smafac.Framework.Core.Domain.Entity;
using Smafac.Framework.Core.Models;
using Smafac.Framework.Core.Repositories.Pages;
using Smafac.Framework.Core.Repositories.Property;
using Smafac.Framework.Core.Repositories.PropertyValue;
using Smafac.Framework.Core.Repositories.Query;
using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Domain.Pages
{
    public abstract class PageQueryer<TEntity, TModel, TPageQueryModel, TPropertyValueModel, TPropertyEntity> :
            EntityHavePropertyQueryer<TEntity, TModel, TPageQueryModel, TPropertyValueModel, TPropertyEntity>,
            IPageQueryer<TModel, TPageQueryModel>
            where TEntity : SaasBaseEntity
            where TModel : SaasBaseModel
            where TPageQueryModel : PageQueryBaseModel
            where TPropertyValueModel : PropertyValueModel
            where TPropertyEntity : PropertyEntity
    {
        public IPageQueryRepository<TEntity, TModel> PageQueryRepository
        {
            get; protected set;
        }

        public virtual PageModel<TModel> QueryPage(TPageQueryModel query)
        {
            var predicate = CreatePredicate(query);
            var subscriberId = UserContext.Current.SubscriberId;
            var models = PageQueryRepository.QueryPage(subscriberId, predicate, query.Skip, query.PageSize);
            base.WrapperModels(models);
            var count = PageQueryRepository.QueryCount(subscriberId, predicate);
            var tableColumns = PropertySearchRepository.SelectTableColumns(subscriberId)
                                .Select(s => new CustomizedColumnModel
                                {
                                    Name = s.Name,
                                    Id = s.Id,
                                }).ToList();
            return new PageModel<TModel>(query)
            {
                PageData = models,
                TotalCount = count,
                TableColumns = tableColumns
            };
        }
    }
}
