using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Smafac.Framework.Models;
using System.ComponentModel.DataAnnotations;

namespace Smafac.Framework.Core.Domain.Exports
{
    class ExportColumnProvider : IExportColumnProvider
    {
        public List<ExportPropertyColumnDescriptor> Provide<TModel>()
        {
            var columns = new List<ExportPropertyColumnDescriptor> { };
            typeof(TModel).GetProperties().ToList().ForEach(property =>
            {
                var exportColumn = property.GetCustomAttribute<ExportColumnAttribute>();
                if (exportColumn == null)
                {
                    return;
                }
                var column = new ExportPropertyColumnDescriptor(property);
                var display = property.GetCustomAttribute<DisplayAttribute>();
                if (display != null)
                {
                    column.DisplayName = display.Name;
                }
                columns.Add(column);
            });
            return columns;
        }
    }
}
