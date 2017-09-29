using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Domain.Exports
{
    public interface IExcelDataHaveColumnExporter: IDataExporter
    {
        byte[] Export<TData, TColumn>(ExportDataHaveColumnModel<TData, TColumn> model)
            where TData : HavePropertyModel
            where TColumn : CustomizedColumnModel;
    }
}
