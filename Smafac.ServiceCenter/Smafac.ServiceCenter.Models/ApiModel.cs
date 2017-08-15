using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.ServiceCenter.Models
{
    public class ApiModel
    {
        public Guid ServiceId { get; set; }
        public string Code { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime PublishTime { get; set; }
    }
}
