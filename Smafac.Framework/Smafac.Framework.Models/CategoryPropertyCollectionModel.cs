using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Models
{
    public class CategoryPropertyCollectionModel : SaasBaseModel
    {
        public Guid CategoryId { get; set; }
        public List<Guid> PropertyIds { get; set; }
    }
}
