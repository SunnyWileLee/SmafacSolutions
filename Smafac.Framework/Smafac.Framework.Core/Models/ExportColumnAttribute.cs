﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Models
{
    public class ExportColumnAttribute : Attribute
    {
        public int Order { get; set; }
    }
}
