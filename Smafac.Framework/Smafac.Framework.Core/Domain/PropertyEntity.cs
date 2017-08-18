using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Domain
{
    public class PropertyEntity : SaasBaseEntity
    {
        [MaxLength(20)]
        public string Name { get; set; }
    }
}
