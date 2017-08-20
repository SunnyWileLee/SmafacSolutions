using Newtonsoft.Json;
using Smafac.Presentation.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Smafac.Presentation.Controllers
{
    [Authorize]
    public class SmafacController : Controller
    {
        protected JsonResult Success(object data = null)
        {
            if (data == null)
            {
                data = new object { };
            }
            ResponseModel result = new ResponseModel
            {
                Data = data
            };
            return Json(result);
        }

        protected JsonResult BoolResult(bool result, string message = null)
        {
            ResponseModel model = new ResponseModel
            {
                Code = result ? 0 : -1,
                Message = message
            };
            return Json(model);
        }


        protected JsonResult Fail(int code, string message)
        {
            if (code == 0)
            {
                throw new ArgumentOutOfRangeException("code不能为0");
            }
            ResponseModel result = new ResponseModel
            {
                Code = code,
                Message = message
            };
            return Json(result);
        }
        protected TJson ReadJsonStream<TJson>() where TJson : class
        {
            StreamReader sr = new StreamReader(HttpContext.Request.InputStream);
            var jsonString = sr.ReadToEnd();
            var json = JsonConvert.DeserializeObject<TJson>(jsonString);
            return json;
        }
    }
}