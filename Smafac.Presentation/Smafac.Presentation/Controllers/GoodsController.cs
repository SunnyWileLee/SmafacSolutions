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

        public GoodsController(IGoodsService goodsService,
                                IGoodsSearchService goodsSearchService)
        {
            _goodsService = goodsService;
            _goodsSearchService = goodsSearchService;
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
        public ActionResult AddGoodsView(Guid? goodsId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddGoods(GoodsModel model)
        {
            var result = _goodsService.AddGoods(model);
            return BoolResult(result);
        }
    }
}