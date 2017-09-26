using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Domain.Exports
{
    public abstract class ExcelExporter
    {
        public virtual byte[] ExportBase(IWorkbook workbook)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                workbook.Write(stream);
                var buffer = stream.GetBuffer();
                stream.Close();
                return buffer;
            }
        }


        protected virtual IWorkbook CreateWorkbook()
        {
            return new XSSFWorkbook();
        }

        protected virtual ISheet CreateSheet(IWorkbook workbook, string name)
        {
            return workbook.CreateSheet(string.IsNullOrEmpty(name) ? "Sheet1" : name);
        }

        protected virtual void SetHead(ISheet sheet, IEnumerable<ExportColumnDescriptor> columns)
        {
            IRow rowHead = sheet.CreateRow(0);
            int columnIndex = 0;
            foreach (var column in columns.OrderBy(s => s.Order))
            {
                SetHead(rowHead, columnIndex, column.DisplayName);
                columnIndex++;
            }
        }

        protected virtual void SetHead(IRow head, int columnIndex, string columnName)
        {
            ICell cell = head.CreateCell(columnIndex);
            cell.SetCellValue(columnName);
        }

        protected abstract void SetRow(ISheet sheet);

        protected virtual void SetRow(IRow row, int columnIndex, string value)
        {
            ICell cell = row.CreateCell(columnIndex);
            cell.SetCellValue(value == null ? string.Empty : value.ToString());
        }
    }
}
