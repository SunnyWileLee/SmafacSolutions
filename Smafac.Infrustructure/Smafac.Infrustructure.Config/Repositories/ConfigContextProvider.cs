﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Infrustructure.Config.Repositories
{
    class ConfigContextProvider : IConfigContextProvider
    {
        public ConfigContext Provide()
        {
            return new ConfigContext();
        }
    }
}
