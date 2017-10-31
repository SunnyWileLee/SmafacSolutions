using Smafac.Framework.Core.Domain.Exports;
using Smafac.Framework.Core.Models;
using Smafac.Framework.Driver;
using Smafac.Pms.Purchase.Applications;
using Smafac.Pms.Purchase.Applications.Category;
using Smafac.Pms.Purchase.Applications.Property;
using Smafac.Pms.Purchase.Models;
using Smafac.Presentation.Domain.Purchase;
using Smafac.Wms.Goods.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Smafac.Presentation.Controllers
{
    public class PurchaseController : SmafacController
    {
        private readonly IPurchaseService _purchaseService;
        private readonly IPurchaseSearchService _purchaseSearchService;
        private readonly IPurchaseCategoryService _purchaseCategoryService;
        private readonly IPurchasePropertyService _purchasePropertyService;
        private readonly IExcelDataHaveColumnExporter _dataExporter;
        private readonly IPurchaseWrapper[] _purchaseWrappers;
        private readonly IGoodsSearchService _goodsSearchService;

        public PurchaseController(IPurchaseService purchaseService,
                                IPurchaseSearchService purchaseSearchService,
                                IPurchaseCategoryService purchaseCategoryService,
                                IPurchasePropertyService purchasePropertyService,
                                IExcelDataHaveColumnExporter dataExporter,
                                ICommandPipeProvider commandPipeProvider,
                                IPurchaseWrapper[] purchaseWrappers,
                                IGoodsSearchService goodsSearchService)
        {
            _purchaseService = purchaseService;
            _purchaseSearchService = purchaseSearchService;
            _purchaseCategoryService = purchaseCategoryService;
            _dataExporter = dataExporter;
            _purchasePropertyService = purchasePropertyService;
            _purchaseWrappers = purchaseWrappers;
            _goodsSearchService = goodsSearchService;
            base.CommandPipeProvider = commandPipeProvider;
        }

        [HttpGet]
        public ActionResult PurchaseView()
        {
            var categories = _purchaseCategoryService.SearchService.GetCategories();
            ViewData["categories"] = categories.Select(s => new SelectListItem { Text = s.Name, Value = s.Id.ToString() });
            return View();
        }
        [HttpGet]
        public ActionResult PurchasePageView(PurchasePageQueryModel query)
        {
            var page = _purchaseSearchService.GetPurchasePage(query);
            var purchases = page.PageData;
            if (purchases.Any())
            {
                _purchaseWrappers.ToList().ForEach(wrapper =>
                {
                    wrapper.Wrapper(purchases);
                });
            }
            ViewData["tableColumns"] = page.TableColumns;
            return View(purchases);
        }
        [HttpPost]
        public ActionResult PurchasePage(PurchasePageQueryModel query)
        {
            var page = _purchaseSearchService.GetPurchasePage(query);
            return Success(page);
        }
        [HttpGet]
        public ActionResult PurchaseAddView(Guid goodsId)
        {
            var categories = _purchaseCategoryService.SearchService.GetLeafCategories()
                            .Select(s => new SelectListItem { Text = s.Name, Value = s.Id.ToString() });
            ViewData["categories"] = categories;
            var purchase = _purchaseService.CreateEmptyPurchase();
            var goods = _goodsSearchService.GetGoods(goodsId);
            purchase.GoodsId = goods.Id;
            purchase.GoodsName = goods.Name;
            return View(purchase);
        }

        [HttpPost]
        public ActionResult AddPurchase(PurchaseModel model)
        {
            var result = _purchaseService.AddPurchase(model);
            return BoolResult(result);
        }
        [HttpPost]
        public ActionResult EditPurchase(PurchaseModel model)
        {
            var result = _purchaseService.UpdateService.UpdatePurchase(model);
            return BoolResult(result);
        }

        [HttpGet]
        public ActionResult PurchaseDetailView(Guid purchaseId)
        {
            var purchase = _purchaseSearchService.GetPurchaseDetail(purchaseId);
            _purchaseWrappers.ToList().ForEach(wrapper =>
            {
                wrapper.Wrapper(new List<PurchaseModel> { purchase.Purchase });
            });
            return View(purchase);
        }

        [HttpGet]
        public ActionResult Export(PurchasePageQueryModel query)
        {
            var purchase = _purchaseSearchService.GetPurchase(query);
            var properties = _purchasePropertyService.SearchService.GetColumns();
            var model = new ExportDataHaveColumnModel<PurchaseModel, PurchasePropertyModel>
            {
                Datas = purchase,
                Columns = properties
            };
            _purchaseWrappers.ToList().ForEach(wrapper =>
            {
                wrapper.Wrapper(purchase);
            });
            var fileName = _dataExporter.CreateFileName("采购单");
            var datas = _dataExporter.Export<PurchaseModel, PurchasePropertyModel>(model);
            return File(datas, "application/ms-excel", fileName);
        }
    }
}