using Smafac.Framework.Core.Applications.Category;
using Smafac.Framework.Core.Domain;
using Smafac.Framework.Core.Models;
using Smafac.Framework.Core.Repositories.Category;
using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Smafac.Framework.Core.Services.Category
{
    public abstract class CategorySearchService<TCategory, TCategoryModel> : ICategorySearchService<TCategoryModel>
        where TCategory : CategoryEntity
        where TCategoryModel : CategoryModel
    {
        public virtual ICategorySearchRepository<TCategory> CategorySearchRepository
        {
            get;
            protected set;
        }

        public virtual List<TCategoryModel> GetCategories()
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var categories = CategorySearchRepository.GetEntities(subscriberId, s => true);
            return Mapper.Map<List<TCategoryModel>>(categories);
        }

        public List<TCategoryModel> GetCategories(Guid parentId)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var categories = CategorySearchRepository.GetCategories(subscriberId, parentId);
            return Mapper.Map<List<TCategoryModel>>(categories);
        }

        public TCategoryModel GetCategory(Guid id)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var category = CategorySearchRepository.GetEntity(subscriberId, id);
            return Mapper.Map<TCategoryModel>(category);
        }

        public CategoryModelSet<TCategoryModel> GetCategoryWithChildren(Guid id)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var category = CategorySearchRepository.GetEntity(subscriberId, id);
            if (category == null)
            {
                return null;
            }
            var children = CategorySearchRepository.GetCategories(subscriberId, category.Id);
            var model = Mapper.Map<TCategoryModel>(category);
            var cs = Mapper.Map<List<TCategoryModel>>(children);
            return new CategoryModelSet<TCategoryModel>(model, cs);
        }

        public List<TCategoryModel> GetLeafCategories()
        {
            var categories = CategorySearchRepository.GetEntities(UserContext.Current.SubscriberId, s => s.NodeType == TreeNodeEntity.LeafNodeType)
                                        .OrderBy(s => s.ParentId).ToList();
            return Mapper.Map<List<TCategoryModel>>(categories);
        }
    }
}
