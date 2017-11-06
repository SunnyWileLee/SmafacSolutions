using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Infrustructure.Base
{
    public abstract class BaseModel
    {
        public BaseModel()
        {
            Id = Guid.NewGuid();
            CreateTime = DateTime.Now;
        }
        public virtual Guid Id { get; set; }
        public virtual DateTime CreateTime { get; set; }
        public string Module { get; set; }
    }
}
