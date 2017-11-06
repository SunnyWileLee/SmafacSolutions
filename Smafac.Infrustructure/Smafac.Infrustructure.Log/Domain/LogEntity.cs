using Smafac.Infrustructure.Base;
using Smafac.Infrustructure.Log.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Infrustructure.Log.Domain
{
    class LogEntity : BaseEntity
    {
        [MaxLength(4000)]
        public string Content { get; set; }
        public LogLevel Level { get; set; }
    }
}
