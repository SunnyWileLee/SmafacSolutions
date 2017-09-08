using Smafac.Presentation.Domain;
using Smafac.Wms.Goods.Applications;
using Smafac.Wms.Goods.Applications.Property;
using Smafac.Wms.Goods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Smafac.Presentation.Controllers
{
    public class GoodsPropertyController : SmafacController
    {
        private readonly IGoodsPropertyService _goodsPropertyService;
        private readonly IPropertyTypeProvider _propertyTypeProvider;

        public GoodsPropertyController(IGoodsPropertyService goodsPropertyService,
                    IPropertyTypeProvider propertyTypeProvider)
        {
            _goodsPropertyService = goodsPropertyService;
            _propertyTypeProvider = propertyTypeProvider;
        }

        [HttpGet]
        public ActionResult GoodsPropertyView()
        {
            var types = _propertyTypeProvider.Provide();
            ViewData["types"] = types;
            var properties = _goodsPropertyService.SearchService.GetColumns();
            return View(properties);
        }

        [HttpGet]
        public ActionResult GoodsPropertyAddView(Guid? propertyId)
        {
            var types = _propertyTypeProvider.Provide();
            ViewData["types"] = types;
            if (propertyId == null)
            {
                return View();
            }
            else
            {
                var property = _goodsPropertyService.SearchService.GetColumn(propertyId.Value);
                return View(property);
            }
        }

        [HttpPost]
        public ActionResult AddGoodsProperty(GoodsPropertyModel model)
        {
            var result = _goodsPropertyService.AddService.AddColumn(model);
            return BoolResult(result);
        }
        [HttpPost]
        public ActionResult EditGoodsProperty(GoodsPropertyModel model)
        {
            var result = _goodsPropertyService.UpdateService.UpdateColumn(model);
            return BoolResult(result);
        }
        [HttpPost]
        public ActionResult DeleteGoodsProperty(Guid id)
        {
            var result = _goodsPropertyService.DeleteService.DeleteColumn(id);
            return BoolResult(result);
        }
    }
}