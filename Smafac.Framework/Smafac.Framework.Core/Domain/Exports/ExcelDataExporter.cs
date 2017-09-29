using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.SS.UserModel;
using Smafac.Framework.Core.Models;

namespace Smafac.Framework.Core.Domain.Exports
{
    public class ExcelDataExporter : ExcelExporter, IExcelDataExporter
    {

        private readonly IExportProperyColumnProvider _exportColumnProvider;

        public ExcelDataExporter(IExportProperyColumnProvider exportColumnProvider)
        {
            _exportColumnProvider = exportColumnProvider;
        }

        public byte[] Export<TData>(ExportDataModel<TData> model) where TData : SaasBaseModel
        {
            IWorkbook workbook = base.CreateWorkbook();
            ISheet sheet = base.CreateSheet(workbook, typeof(TData).Name);
            var columns = _exportColumnProvider.Provide<TData>();
            base.SetHead(sheet, columns);
            var rowIndex = 1;
            foreach (var data in model.Datas)
            {
                SetRows<TData>(sheet, data, rowIndex, columns);
                rowIndex++;
            }
            return base.ExportBase(workbook);
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

        protected virtual void SetRows<TData>(ISheet sheet, TData data, int rowIndex, List<ExportPropertyColumnDescriptor> columns) where TData : SaasBaseModel
        {
            IRow rowBody = sheet.CreateRow(rowIndex);
            foreach (var column in columns)
            {
                ICell cell = rowBody.CreateCell(column.Order);
                var value = column.Property.GetValue(data);
                cell.SetCellValue(value == null ? string.Empty : value.ToString());
            }
        }
    }
}
