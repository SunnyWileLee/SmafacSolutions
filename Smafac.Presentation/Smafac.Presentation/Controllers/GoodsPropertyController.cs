using Smafac.Wms.Goods.Applications;
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

        public GoodsPropertyController(IGoodsPropertyService goodsPropertyService)
        {
            _goodsPropertyService = goodsPropertyService;
        }

        [HttpGet]
        public ActionResult GoodsPropertyView()
        {
            var properties = _goodsPropertyService.GetProperties();
            return View(properties);
        }

        [HttpPost]
        public ActionResult AddGoodsProperty(GoodsPropertyModel model)
        {
            var result = _goodsPropertyService.AddProperty(model);
            return BoolResult(result);
        }

        [HttpPost]
        public ActionResult DeleteGoodsProperty(Guid id)
        {
            var result = _goodsPropertyService.DeleteProperty(id);
            return BoolResult(result);
        }
    }
}