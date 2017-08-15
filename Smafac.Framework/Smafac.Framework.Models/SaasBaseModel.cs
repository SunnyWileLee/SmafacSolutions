using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Models
{
    public class SaasBaseModel
    {
        public SaasBaseModel()
        {
            Id = Guid.NewGuid();
            CreateTime = DateTime.Now;
        }
        public Guid Id { get; set; }
        public Guid SubscriberId { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
