using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Infrustructure.Base
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid();
            CreateTime = DateTime.Now;
        }
        [Key]
        public virtual Guid Id { get; set; }
        public virtual DateTime CreateTime { get; set; }
        [MaxLength(100)]
        public string Module { get; set; }
    }
}
