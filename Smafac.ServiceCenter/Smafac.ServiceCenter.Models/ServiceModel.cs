using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.ServiceCenter.Models
{
    public class ServiceModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Domain { get; set; }
        public DateTime PublishTime { get; set; }
        public string Descrtiption { get; set; }
    }
}
