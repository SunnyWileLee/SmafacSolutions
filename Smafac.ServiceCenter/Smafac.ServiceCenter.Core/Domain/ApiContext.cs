using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.ServiceCenter.Core.Domain
{
    class ApiContext
    {
        public ApiDescription ApiDescription { get; set; }
        public ServiceDescription ServiceDescription { get; set; }
        public string Body { get; set; }

        public string RequestUrl
        {
            get
            {
                return string.Format("http://{0}/{1}", ServiceDescription.Domain, ApiDescription.Url);
            }
        }
    }
}
