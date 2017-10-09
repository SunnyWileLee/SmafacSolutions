using Smafac.Framework.Core.Domain.Exports;
using Smafac.Framework.Core.Models;
using Smafac.Framework.Driver;
using Smafac.Wms.Goods.Applications;
using Smafac.Wms.Goods.Applications.Category;
using Smafac.Wms.Goods.Applications.Property;
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
        private readonly IGoodsPropertyService _goodsPropertyService;
        private readonly IExcelDataHaveColumnExporter _dataExporter;

        public GoodsController(IGoodsService goodsService,
                                IGoodsSearchService goodsSearchService,
                                IGoodsCategoryService goodsCategoryService,
                                IGoodsPropertyService goodsPropertyService,
                                IExcelDataHaveColumnExporter dataExporter,
                                ICommandPipeProvider commandPipeProvider)
        {
            _goodsService = goodsService;
            _goodsSearchService = goodsSearchService;
            _goodsCategoryService = goodsCategoryService;
            _dataExporter = dataExporter;
            _goodsPropertyService = goodsPropertyService;
            base.CommandPipeProvider = commandPipeProvider;
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
        [HttpGet]
        public ActionResult Export(GoodsPageQueryModel query)
        {
            var goods = _goodsSearchService.GetGoods(query);
            var properties = _goodsPropertyService.SearchService.GetColumns();
            var model = new ExportDataHaveColumnModel<GoodsModel, GoodsPropertyModel>
            {
                Datas = goods,
                Columns = properties
            };
            var fileName = _dataExporter.CreateFileName("商品");
            var datas = _dataExporter.Export<GoodsModel, GoodsPropertyModel>(model);
            return File(datas, "application/ms-excel", fileName);
        }
    }
}