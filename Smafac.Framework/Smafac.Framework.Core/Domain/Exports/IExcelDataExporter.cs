﻿using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Domain.Exports
{
    public interface IExcelDataExporter
    {
        byte[] Export<TData>(ExportDataModel<TData> model)
            where TData : SaasBaseModel;
    }
}
