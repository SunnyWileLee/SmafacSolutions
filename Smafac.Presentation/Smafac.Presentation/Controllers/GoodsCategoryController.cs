using Smafac.Wms.Goods.Applications;
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
        public ActionResult GoodsCategorySliceView(Guid categoryId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddGoodsCategory(GoodsCategoryModel model)
        {
            var result = _goodsCategoryService.AddCategory(model);
            return BoolResult(result);
        }

        [HttpGet]
        public ActionResult GoodsCategoryPropertyBindView(Guid categoryId)
        {
            var category = _goodsCategoryService.GetCategory(categoryId);
            ViewData["category"] = category;
            var properties = _goodsPropertyService.GetProperties();
            var bounds = _goodsCategoryPropertyService.GetProperties(categoryId).Select(s => s.Id).ToList();
            ViewData["boundIds"] = bounds;
            return View(properties);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult BindProperties(GoodsCategoryPropertyColletionModel model)
        {
            var result = _goodsCategoryPropertyService.BindProperties(model.CategoryId, model.PropertyIds);
            return Success(result);
        }

        [HttpGet]
        public ActionResult GoodsCategoryPropertyValueView(Guid categoryId)
        {
            var properties = _goodsCategoryPropertyService.GetPropertiesIncludeParents(categoryId);
            return View(properties);
        }
    }
}