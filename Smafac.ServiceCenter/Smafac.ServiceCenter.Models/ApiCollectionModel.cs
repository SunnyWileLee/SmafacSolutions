using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.ServiceCenter.Models
{
    public class ApiCollectionModel
    {
        public ServiceModel Service { get; set; }
        public IEnumerable<ApiModel> Apis { get; set; }
    }
}
