﻿using Smafac.Wms.Goods.Applications;
using Smafac.Wms.Goods.Applications.Category;
using Smafac.Wms.Goods.Models;
using System;
using System.Collections.Generic;
using System.IO;
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

        public GoodsController(IGoodsService goodsService,
                                IGoodsSearchService goodsSearchService,
                                IGoodsCategoryService goodsCategoryService)
        {
            _goodsService = goodsService;
            _goodsSearchService = goodsSearchService;
            _goodsCategoryService = goodsCategoryService;
        }

        [HttpGet]
        public ActionResult GoodsView()
        {
            var categories = _goodsCategoryService.SearchService.GetCategories();
            ViewData["categories"] = categories.Select(s => new SelectListItem { Text = s.Name, Value = s.Id.ToString() });
            return View();
        }
        [HttpGet]
        public ActionResult GoodsPageView(GoodsPageQueryModel query)
        {
            var page = _goodsSearchService.GetGoodsPage(query);
            ViewData["tableColumns"] = page.TableColumns;
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
            var categories = _goodsCategoryService.SearchService.GetLeafCategories()
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
        [HttpPost]
        public ActionResult EditGoods(GoodsModel model)
        {
            var result = _goodsService.UpdateService.UpdateGoods(model);
            return BoolResult(result);
        }

        [HttpGet]
        public ActionResult GoodsDetailView(Guid goodsId)
        {
            var goods = _goodsSearchService.GetGoodsDetail(goodsId);
            return View(goods);
        }
        [HttpPost]
        public ActionResult SearchGoods(string key)
        {
            var goods = _goodsSearchService.GetGoods(key);
            return Success(goods);
        }
        [HttpPost]
        public ActionResult Export(GoodsPageQueryModel query)
        {
            Excel excel = new Excel();
            Stream dataStream = excel.Export(titles.ToArray(), data);
            return new FileStreamResult(dataStream, "application/ms-excel") { FileDownloadName = "exportInfo.xlsx" };
        }
    }
}