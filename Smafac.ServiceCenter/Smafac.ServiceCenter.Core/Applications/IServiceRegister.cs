﻿using Smafac.ServiceCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.ServiceCenter.Core.Applications
{
    public interface IServiceRegister
    {
        bool Register(ServiceModel service, IEnumerable<ApiModel> apis);
    }
}
