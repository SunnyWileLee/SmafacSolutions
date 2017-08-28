using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Domain
{
    public abstract class SaasBaseEntity
    {
        public SaasBaseEntity()
        {
            Id = Guid.NewGuid();
            CreateTime = DateTime.Now;
        }
        [Key]
        public virtual Guid Id { get; set; }
        public virtual Guid SubscriberId { get; set; }
        public virtual DateTime CreateTime { get; set; }

        public virtual bool IsAllowAnonymous()
        {
            return SubscriberId.Equals(Guid.Empty);
        }
    }
}
