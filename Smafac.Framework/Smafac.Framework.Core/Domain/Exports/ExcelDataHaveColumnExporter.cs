using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Framework.Models;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace Smafac.Framework.Core.Domain.Exports
{
    class ExcelDataHaveColumnExporter : ExcelExporter, IExcelDataHaveColumnExporter
    {
        private readonly IExportProperyColumnProvider _exportColumnProvider;

        public ExcelDataHaveColumnExporter(IExportProperyColumnProvider exportColumnProvider)
        {
            _exportColumnProvider = exportColumnProvider;
        }

        public byte[] Export<TData, TColumn>(ExportDataHaveColumnModel<TData, TColumn> model)
            where TData : HavePropertyModel
            where TColumn : CustomizedColumnModel
        {
            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet(typeof(TData).Name);
            var columns = _exportColumnProvider.Provide<TData>();
            var customizedColumns = model.Columns;
            //表头  
            IRow rowHead = sheet.CreateRow(0);
            int columnIndex = 0;
            foreach (var column in columns)
            {
                ICell cell = rowHead.CreateCell(columnIndex);
                cell.SetCellValue(column.DisplayName);
                columnIndex++;
            }
            foreach (var column in customizedColumns)
            {
                ICell cell = rowHead.CreateCell(columnIndex);
                cell.SetCellValue(column.Name);
                columnIndex++;
            }

            var rowIndex = 1;
            foreach (var data in model.Datas)
            {
                IRow rowBody = sheet.CreateRow(rowIndex);
                int columnValueIndex = 0;
                foreach (var column in columns)
                {
                    ICell cell = rowBody.CreateCell(columnValueIndex);
                    var value = column.Property.GetValue(data);
                    cell.SetCellValue(value == null ? string.Empty : value.ToString());
                    columnValueIndex++;
                }
                foreach (var column in customizedColumns)
                {
                    ICell cell = rowBody.CreateCell(columnValueIndex);
                    cell.SetCellValue(data.GetPropertyValue(column.Id));
                    columnValueIndex++;
                }
                rowIndex++;
            }
            using (MemoryStream stream = new MemoryStream())
            {
                workbook.Write(stream);
                var buffer = stream.GetBuffer();
                stream.Close();
                return buffer;
            }
        }
    }
}
