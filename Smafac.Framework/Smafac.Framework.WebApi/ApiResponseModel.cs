using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.WebApi
{
    public class ApiResponseModel
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public static ApiResponseModel Success(object data)
        {
            return new ApiResponseModel
            {
                Data = data
            };
        }

        public static ApiResponseModel Fail(string message, int code = -1)
        {
            return new ApiResponseModel
            {
                Code = code,
                Message = message
            };
        }
    }
}
