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
    class ExportPropertyColumnProvider : IExportProperyColumnProvider
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
                column.Order = exportColumn.Order;
                var display = property.GetCustomAttribute<DisplayAttribute>();
                if (display != null)
                {
                    column.DisplayName = display.Name;
                }
                columns.Add(column);
            });
            var sorteds = columns.OrderBy(s => s.Order).ToList();
            SortProperties(sorteds);
            return sorteds;
        }

        protected void SortProperties(List<ExportPropertyColumnDescriptor> properties)
        {
            for (int index = 0; index < properties.Count; index++)
            {
                properties[index].Order = index;
            }
        }
    }
}
