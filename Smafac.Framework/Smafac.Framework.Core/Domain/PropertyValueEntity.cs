using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Domain
{
    public class PropertyValueEntity : SaasBaseEntity
    {
        public Guid PropertyId { get; set; }
        [MaxLength(100)]
        public string Value { get; set; }
    }
}
