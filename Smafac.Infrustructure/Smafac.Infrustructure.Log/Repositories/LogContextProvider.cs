﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Infrustructure.Log.Repositories
{
    class LogContextProvider : ILogContextProvider
    {
        public LogContext Provide()
        {
            return new LogContext();
        }
    }
}