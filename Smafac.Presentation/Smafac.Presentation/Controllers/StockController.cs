using Smafac.Framework.Core.Domain.Exports;
using Smafac.Framework.Core.Models;
using Smafac.Framework.Driver;
using Smafac.Presentation.Domain.Purchase;
using Smafac.Wms.Goods.Applications;
using Smafac.Wms.Stock.Applications;
using Smafac.Wms.Stock.Applications.Category;
using Smafac.Wms.Stock.Applications.Property;
using Smafac.Wms.Stock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Smafac.Presentation.Controllers
{
    public class StockController : SmafacController
    {
        private readonly IStockService _stockService;
        private readonly IStockSearchService _stockSearchService;
        private readonly IStockCategoryService _stockCategoryService;
        private readonly IStockPropertyService _stockPropertyService;
        private readonly IExcelDataHaveColumnExporter _dataExporter;
        private readonly IStockWrapper[] _stockWrappers;
        private readonly IGoodsSearchService _goodsSearchService;

        public StockController(IStockService stockService,
                                IStockSearchService stockSearchService,
                                IStockCategoryService stockCategoryService,
                                IStockPropertyService stockPropertyService,
                                IExcelDataHaveColumnExporter dataExporter,
                                ICommandPipeProvider commandPipeProvider,
                                IStockWrapper[] stockWrappers,
                                IGoodsSearchService goodsSearchService)
        {
            _stockService = stockService;
            _stockSearchService = stockSearchService;
            _stockCategoryService = stockCategoryService;
            _dataExporter = dataExporter;
            _stockPropertyService = stockPropertyService;
            _stockWrappers = stockWrappers;
            _goodsSearchService = goodsSearchService;
            base.CommandPipeProvider = commandPipeProvider;
        }

        [HttpGet]
        public ActionResult StockView(Guid? goodsId)
        {
            var categories = _stockCategoryService.SearchService.GetCategories();
            ViewData["categories"] = categories.Select(s => new SelectListItem { Text = s.Name, Value = s.Id.ToString() });
            ViewData["goodsId"] = goodsId;
            return View();
        }
        [HttpGet]
        public ActionResult StockPageView(StockPageQueryModel query)
        {
            var page = _stockSearchService.GetStockPage(query);
            var stocks = page.PageData;
            if (stocks.Any())
            {
                _stockWrappers.ToList().ForEach(wrapper =>
                {
                    wrapper.Wrapper(stocks);
                });
            }
            ViewData["tableColumns"] = page.TableColumns;
            return View(stocks);
        }
        [HttpPost]
        public ActionResult StockPage(StockPageQueryModel query)
        {
            var page = _stockSearchService.GetStockPage(query);
            return Success(page);
        }
        [HttpGet]
        public ActionResult StockAddView(Guid goodsId)
        {
            var categories = _stockCategoryService.SearchService.GetLeafCategories()
                            .Select(s => new SelectListItem { Text = s.Name, Value = s.Id.ToString() });
            ViewData["categories"] = categories;
            var stock = _stockService.CreateEmptyStock();
            var goods = _goodsSearchService.GetGoods(goodsId);
            stock.GoodsId = goods.Id;
            stock.GoodsName = goods.Name;
            return View(stock);
        }

        [HttpPost]
        public ActionResult AddStock(StockModel model)
        {
            var result = _stockService.AddStock(model);
            return BoolResult(result);
        }
        [HttpPost]
        public ActionResult EditStock(StockModel model)
        {
            var result = _stockService.UpdateService.UpdateStock(model);
            return BoolResult(result);
        }

        [HttpGet]
        public ActionResult StockDetailView(Guid stockId)
        {
            var stock = _stockSearchService.GetStockDetail(stockId);
            _stockWrappers.ToList().ForEach(wrapper =>
            {
                wrapper.Wrapper(new List<StockModel> { stock.Stock });
            });
            return View(stock);
        }

        [HttpGet]
        public ActionResult Export(StockPageQueryModel query)
        {
            var stock = _stockSearchService.GetStock(query);
            var properties = _stockPropertyService.SearchService.GetColumns();
            var model = new ExportDataHaveColumnModel<StockModel, StockPropertyModel>
            {
                Datas = stock,
                Columns = properties
            };
            _stockWrappers.ToList().ForEach(wrapper =>
            {
                wrapper.Wrapper(stock);
            });
            var fileName = _dataExporter.CreateFileName("库存记录");
            var datas = _dataExporter.Export<StockModel, StockPropertyModel>(model);
            return File(datas, "application/ms-excel", fileName);
        }
    }
}