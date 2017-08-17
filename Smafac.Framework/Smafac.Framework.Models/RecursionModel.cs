﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Models
{
    public class RecursionModel : SaasBaseModel
    {
        public Guid ParentId { get; set; }

        public virtual bool IsRoot()
        {
            return ParentId == Guid.Empty;
        }
    }
}
