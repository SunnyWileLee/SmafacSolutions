using Smafac.ServiceCenter.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.ServiceCenter.Core.Domain
{
    [Table("AppClient")]
    class AppClientEntity
    {
        public string AppId { get; set; }
        public string AppKey { get; set; }
        public string Name { get; set; }
        public AppClientType Type { get; set; }

        public void SubcribleService(ServiceEntity service)
        {

        }
    }
}
