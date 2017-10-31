using AutoMapper;
using Smafac.Framework.Core.Models;
using Smafac.Framework.Core.Repositories;
using Smafac.Framework.Core.Repositories.Query;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Smafac.Framework.Core.Domain.Entity
{
    public abstract class EntityQueryer<TEntity, TModel, TPageQueryModel> : IEntityQueryer<TModel, TPageQueryModel>
            where TEntity : SaasBaseEntity
            where TModel : SaasBaseModel
            where TPageQueryModel : PageQueryBaseModel
    {
        public IQueryExpressionCreaterProvider QueryExpressionCreaterProvider
        {
            get; protected set;
        }

        public IEntitySearchRepository<TEntity> EntitySearchRepository
        {
            get; protected set;
        }

        public virtual List<TModel> Query(TPageQueryModel query)
        {
            var predicate = CreatePredicate(query);
            var models = QueryModels(predicate);
            WrapperModels(models);
            return models;
        }

        protected virtual List<TModel> QueryModels(Expression<Func<TEntity, bool>> predicate)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var entities = EntitySearchRepository.GetEntities(subscriberId, predicate);
            var models = ConvertModels(entities);
            return models;
        }

        protected virtual List<TModel> ConvertModels(List<TEntity> entities)
        {
            return Mapper.Map<List<TModel>>(entities);
        }

        protected virtual void WrapperModels(IEnumerable<TModel> models)
        {
            return;
        }

        protected virtual Expression<Func<TEntity, bool>> CreatePredicate(TPageQueryModel query)
        {
            return QueryExpressionCreaterProvider.Provide<TEntity>().Create(query);
        }
    }
}
