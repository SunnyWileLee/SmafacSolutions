using Smafac.Infrustructure.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Infrustructure.Config.Domain
{
    [Table("Config")]
    class ConfigEntity : BaseEntity
    {
        [MaxLength(100)]
        public string Key { get; set; }
        [MaxLength(4000)]
        public string Value { get; set; }
    }
}
