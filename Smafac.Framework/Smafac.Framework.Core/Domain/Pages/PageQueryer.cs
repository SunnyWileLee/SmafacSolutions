using AutoMapper;
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
    public abstract class PageQueryer<TEntity, TModel, TPageQueryModel, TPropertyValueModel, TPropertyEntity> : IPageQueryer<TModel, TPageQueryModel>
            where TEntity : SaasBaseEntity
            where TModel : SaasBaseModel
            where TPageQueryModel : PageQueryBaseModel
            where TPropertyValueModel : PropertyValueModel
            where TPropertyEntity : PropertyEntity
    {
        protected virtual bool IsLoadProperties
        {
            get
            {
                return true;
            }
        }

        public IQueryExpressionCreaterProvider QueryExpressionCreaterProvider
        {
            get; protected set;
        }

        public IPageQueryRepository<TEntity, TModel> PageQueryRepository
        {
            get; protected set;
        }

        public IPropertyValueSearchRepository<TPropertyValueModel> PropertyValueSearchRepository
        {
            get; protected set;
        }

        public IPropertySearchRepository<TPropertyEntity> PropertySearchRepository
        {
            get; protected set;
        }

        public virtual PageModel<TModel> Query(TPageQueryModel query)
        {
            var predicate = CreatePredicate(query);
            var subscriberId = UserContext.Current.SubscriberId;
            var models = PageQueryRepository.QueryPage(subscriberId, predicate, query.Skip, query.PageSize);
            if (models.Any() && IsLoadProperties)
            {
                LoadProperties(models);
            }
            LoadOthers(models);
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

        protected virtual void LoadProperties(List<TModel> models)
        {
            var ids = models.Select(s => s.Id);
            var properties = PropertyValueSearchRepository.GetPropertyValues(UserContext.Current.SubscriberId, ids);
            models.ForEach(model =>
            {
                SetPropertyValues(model, properties.FirstOrDefault(s => s.Key == model.Id));
            });
        }

        protected abstract void SetPropertyValues(TModel model, IEnumerable<TPropertyValueModel> properties);

        protected virtual void LoadOthers(List<TModel> models)
        {
            return;
        }

        protected virtual Expression<Func<TEntity, bool>> CreatePredicate(TPageQueryModel query)
        {
            return QueryExpressionCreaterProvider.Provide<TEntity>().Create(query);
        }

        protected virtual List<TPropertyValueModel> WrapperPropertyValues(IEnumerable<TPropertyValueModel> properties)
        {
            return properties == null ? new List<TPropertyValueModel>() : properties.ToList();
        }
    }
}
