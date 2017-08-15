using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.ServiceCenter.Core.Domain
{
    class ServiceDescription
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Domain { get; set; }
    }
}
