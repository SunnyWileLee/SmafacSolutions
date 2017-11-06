using Smafac.Infrustructure.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Infrustructure.Config.Models
{
    public class ConfigModel : BaseModel
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
