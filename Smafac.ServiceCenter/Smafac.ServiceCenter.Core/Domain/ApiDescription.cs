﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.ServiceCenter.Core.Domain
{
    class ApiDescription
    {
        public string Code { get; set; }
        public string Url { get; set; }
        public Guid ServiceId { get; set; }
    }
}
