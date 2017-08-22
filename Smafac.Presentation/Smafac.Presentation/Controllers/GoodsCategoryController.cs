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

        public GoodsCategoryController(IGoodsCategoryService goodsCategoryService)
        {
            _goodsCategoryService = goodsCategoryService;
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
    }
}