using AutoMapper;
using Smafac.Framework.Core.Domain;
using Smafac.Framework.Core.Models;
using Smafac.Wms.Goods.Applications;
using Smafac.Wms.Goods.Models;
using Smafac.Wms.Goods.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Services
{
    class GoodsCategroySearchService : IGoodsCategroySearchService
    {
        private readonly IGoodsCategoryRepository _goodsCategoryRepository;

        public GoodsCategroySearchService(IGoodsCategoryRepository goodsCategoryRepository)
        {
            _goodsCategoryRepository = goodsCategoryRepository;
        }

        public List<GoodsCategoryModel> GetCategories(Guid parentId)
        {
            var categories = _goodsCategoryRepository.GetCategories(UserContext.Current.SubscriberId, parentId);
            var models = Mapper.Map<List<GoodsCategoryModel>>(categories);
            return models;
        }

        public GoodsCategoryModel GetCategory(Guid id)
        {
            var category = _goodsCategoryRepository.GetCategory(UserContext.Current.SubscriberId, id);
            return Mapper.Map<GoodsCategoryModel>(category);
        }

        public GoodsCategoryModel GetCategoryWithChildren(Guid id)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var category = _goodsCategoryRepository.GetCategory(subscriberId, id);
            if (category == null)
            {
                return null;
            }
            var children = _goodsCategoryRepository.GetCategories(subscriberId, category.Id);
            var model = Mapper.Map<GoodsCategoryModel>(category);
            model.Children = Mapper.Map<List<GoodsCategoryModel>>(children);
            return model;
        }

        public List<GoodsCategoryModel> GetLeafCategories()
        {
            var categories = _goodsCategoryRepository.GetCategories(UserContext.Current.SubscriberId, s => s.NodeType == TreeNodeEntity.LeafNodeType)
                                                    .OrderBy(s => s.ParentId).ToList();
            return Mapper.Map<List<GoodsCategoryModel>>(categories);
        }
    }
}
