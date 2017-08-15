﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Infrustructure
{
    public interface IHttpInvoker
    {
        string Invoke(string url, string body);
    }
}
