﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Domain.Exports
{
    public interface IDataExporter
    {
        string CreateFileName(string module);
    }
}
