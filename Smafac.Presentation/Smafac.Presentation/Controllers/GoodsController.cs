using Smafac.Wms.Goods.Applications;
using Smafac.Wms.Goods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Smafac.Presentation.Controllers
{
    public class GoodsController : SmafacController
    {
        private readonly IGoodsService _goodsService;
        private readonly IGoodsSearchService _goodsSearchService;
        private readonly IGoodsCategoryService _goodsCategoryService;
        private readonly IGoodsCategroySearchService _goodsCategroySearchService;

        public GoodsController(IGoodsService goodsService,
                                IGoodsSearchService goodsSearchService,
                                IGoodsCategoryService goodsCategoryService,
                                IGoodsCategroySearchService goodsCategroySearchService)
        {
            _goodsService = goodsService;
            _goodsSearchService = goodsSearchService;
            _goodsCategoryService = goodsCategoryService;
            _goodsCategroySearchService = goodsCategroySearchService;
        }

        [HttpGet]
        public ActionResult GoodsView()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GoodsPageView(GoodsPageQueryModel query)
        {
            var page = _goodsSearchService.GetGoodsPage(query);
            return View(page.PageData);
        }
        [HttpPost]
        public ActionResult GoodsPage(GoodsPageQueryModel query)
        {
            var page = _goodsSearchService.GetGoodsPage(query);
            return Success(page);
        }
        [HttpGet]
        public ActionResult GoodsAddView()
        {
            var categories = _goodsCategroySearchService.GetLeafCategories()
                            .Select(s => new SelectListItem { Text = s.Name, Value = s.Id.ToString() });
            ViewData["categories"] = categories;
            var goods = _goodsService.CreateEmptyGoods();
            return View(goods);
        }

        [HttpPost]
        public ActionResult AddGoods(GoodsModel model)
        {
            var result = _goodsService.AddGoods(model);
            return BoolResult(result);
        }

        [HttpGet]
        public ActionResult GoodsDetailView(Guid goodsId)
        {
            var goods = _goodsSearchService.GetGoodsDetail(goodsId);
            return View(goods);
        }
    }
}