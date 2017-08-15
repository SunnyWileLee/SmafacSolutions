using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Sdk
{
    public class ResponseModel
    {
        public string Response { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
        public TModel ConvertResponse<TModel>() where TModel : class
        {
            return JsonConvert.DeserializeObject<TModel>(Response);
        }

        public bool IsSuccess
        {
            get
            {
                return Code.Equals(0);
            }
        }
    }
}
