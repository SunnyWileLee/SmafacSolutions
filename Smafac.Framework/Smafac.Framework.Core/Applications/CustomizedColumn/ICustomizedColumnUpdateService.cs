﻿using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Applications.CustomizedColumn
{
    public interface ICustomizedColumnUpdateService<TCustomizedColumnModel> where TCustomizedColumnModel : CustomizedColumnModel
    {
        bool UpdateColumn(TCustomizedColumnModel model);
    }
}
