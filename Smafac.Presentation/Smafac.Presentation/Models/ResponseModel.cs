using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Smafac.Presentation.Models
{
    public class ResponseModel
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public bool IsSuccess()
        {
            return this.Code == 0;
        }
    }
}