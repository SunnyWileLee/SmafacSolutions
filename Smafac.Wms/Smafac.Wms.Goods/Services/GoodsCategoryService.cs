using Smafac.Wms.Goods.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Wms.Goods.Models;
using Smafac.Wms.Goods.Repositories;
using AutoMapper;
using Smafac.Wms.Goods.Domain;
using Smafac.Framework.Core.Models;

namespace Smafac.Wms.Goods.Services
{
    class GoodsCategoryService : IGoodsCategoryService
    {
        private readonly IGoodsCategoryRepository _goodsCategoryRepository;

        public GoodsCategoryService(IGoodsCategoryRepository goodsCategoryRepository)
        {
            _goodsCategoryRepository = goodsCategoryRepository;
        }

        public bool AddCategory(GoodsCategoryModel model)
        {
            var category = Mapper.Map<GoodsCategoryEntity>(model);
            category.SubscriberId = UserContext.Current.SubscriberId;
            return _goodsCategoryRepository.AddCategory(category);
        }

        public bool DeleteCategory(Guid categoryId)
        {
            return _goodsCategoryRepository.DeleteCategory(UserContext.Current.SubscriberId, categoryId);
        }

        public List<GoodsCategoryModel> GetCategories(Guid parentId)
        {
            var categories = _goodsCategoryRepository.GetCategories(UserContext.Current.SubscriberId, parentId);
            var models = Mapper.Map<List<GoodsCategoryModel>>(categories);
            return models;
        }

        public bool UpdateCategory(GoodsCategoryModel model)
        {
            var category = Mapper.Map<GoodsCategoryEntity>(model);
            return _goodsCategoryRepository.UpdateCategory(category);
        }
    }
}
