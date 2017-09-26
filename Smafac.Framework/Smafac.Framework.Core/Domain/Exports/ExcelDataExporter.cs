using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.SS.UserModel;
using Smafac.Framework.Models;

namespace Smafac.Framework.Core.Domain.Exports
{
    public class ExcelDataExporter : ExcelExporter, IExcelDataExporter
    {

        private readonly IExportColumnProvider _exportColumnProvider;

        public ExcelDataExporter(IExportColumnProvider exportColumnProvider)
        {
            _exportColumnProvider = exportColumnProvider;
        }

        public byte[] Export<TData>(ExportDataModel<TData> model) where TData : SaasBaseModel
        {
            IWorkbook workbook = base.CreateWorkbook();
            ISheet sheet = base.CreateSheet(workbook,typeof(TData).Name);

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
                    cell.SetCellValue(data.GetValue(column.Id.ToString()));
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
        /// <summary>
        /// 表头  
        /// </summary>
        /// <typeparam name="TData"></typeparam>
        /// <param name="sheet"></param>
        /// <param name="model"></param>
        protected virtual void SetHead(ISheet sheet, List<ExportPropertyColumnDescriptor> columns)
        {
            IRow rowHead = sheet.CreateRow(0);
            int columnIndex = 0;
            foreach (var column in columns)
            {
                base.SetHead(rowHead, columnIndex, column.DisplayName);
                columnIndex++;
            }
        }

        protected virtual void SetRows<TData>(ISheet sheet, ExportDataModel<TData> model) where TData : SaasBaseModel
        {
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
                    cell.SetCellValue(data.GetValue(column.Id.ToString()));
                    columnValueIndex++;
                }
                rowIndex++;
            }
            columnIndex++;
            }
        }

        protected override void SetHead(ISheet sheet)
        {
            //表头  
            IRow rowHead = sheet.CreateRow(0);      
        }

        protected override void SetRow(ISheet sheet)
        {
            throw new NotImplementedException();
        }
    }
}
