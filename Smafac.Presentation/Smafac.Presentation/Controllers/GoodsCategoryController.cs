﻿using Smafac.Framework.Models;
using Smafac.Wms.Goods.Applications;
using Smafac.Wms.Goods.Applications.Category;
using Smafac.Wms.Goods.Applications.Property;
using Smafac.Wms.Goods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Smafac.Presentation.Controllers
{
    public class GoodsCategoryController : SmafacController
    {
        private readonly IGoodsCategoryService _goodsCategoryService;
        private readonly IGoodsCategoryPropertyService _goodsCategoryPropertyService;
        private readonly IGoodsPropertyService _goodsPropertyService;

        public GoodsCategoryController(IGoodsCategoryService goodsCategoryService,
                                        IGoodsCategoryPropertyService goodsCategoryPropertyService,
                                        IGoodsPropertyService goodsPropertyService
                                        )
        {
            _goodsCategoryService = goodsCategoryService;
            _goodsCategoryPropertyService = goodsCategoryPropertyService;
            _goodsPropertyService = goodsPropertyService;
        }
        [HttpGet]
        public ActionResult GoodsCategoryView()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GoodsCategorySliceView(Guid? categoryId, int slice)
        {
            CategoryModelSet<GoodsCategoryModel> model = (categoryId == null || categoryId.Value == Guid.Empty)
                                         ? new CategoryModelSet<GoodsCategoryModel> { Children = _goodsCategoryService.SearchService.GetCategories(Guid.Empty), Category = new GoodsCategoryModel { Id = Guid.Empty } }
                                         : _goodsCategoryService.SearchService.GetCategoryWithChildren(categoryId.Value);
            ViewData["slice"] = slice;
            return View(model);
        }

        [HttpPost]
        public ActionResult AddGoodsCategory(GoodsCategoryModel model)
        {
            var result = _goodsCategoryService.AddService.AddCategory(model);
            return BoolResult(result);
        }

        [HttpGet]
        public ActionResult GoodsCategoryPropertyBindView(Guid categoryId)
        {
            var category = _goodsCategoryService.SearchService.GetCategory(categoryId);
            ViewData["category"] = category;
            var properties = _goodsPropertyService.SearchService.GetProperties();
            var bounds = _goodsCategoryPropertyService.GetProperties(categoryId).Select(s => s.Id).ToList();
            ViewData["boundIds"] = bounds;
            return View(properties);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult BindProperties(GoodsCategoryPropertyColletionModel model)
        {
            var result = _goodsCategoryPropertyService.BindProperties(model.CategoryId, model.PropertyIds);
            return BoolResult(result);
        }

        [HttpGet]
        public ActionResult GoodsCategoryPropertyValueView(Guid categoryId)
        {
            var properties = _goodsCategoryPropertyService.GetPropertiesIncludeParents(categoryId);
            return View(properties);
        }
    }
}