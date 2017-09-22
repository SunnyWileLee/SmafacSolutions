using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Smafac.Framework.Models
{
    public abstract class SaasBaseModel : IExportable
    {
        public SaasBaseModel()
        {
            Id = Guid.NewGuid();
            CreateTime = DateTime.Now;
        }
        public virtual Guid Id { get; set; }
        public virtual Guid SubscriberId { get; set; }
        [Display(Name = "创建时间")]
        [ExportColumn]
        public virtual DateTime CreateTime { get; set; }

        public virtual Dictionary<string, string> GetColumns()
        {
            var columns = GetCustomizedColumns();

            this.GetType().GetProperties().ToList().ForEach(property =>
            {
                var exportColumn = property.GetCustomAttribute<ExportColumnAttribute>();
                if (exportColumn == null)
                {
                    return;
                }
                var display = property.GetCustomAttribute<DisplayAttribute>();
                var displayName = display == null ? property.Name : display.Name;
                columns.Add(property.Name, displayName);
            });

            return columns;
        }

        protected virtual Dictionary<string, string> GetCustomizedColumns()
        {
            return new Dictionary<string, string>();
        }
    }
}
