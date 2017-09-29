using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Smafac.Presentation.Domain
{
    class PropertyTypeProvider : IPropertyTypeProvider
    {
        public IEnumerable<SelectListItem> Provide()
        {
            var items = new List<SelectListItem>();
            var type = typeof(PropertyType);
            var values = Enum.GetValues(type);
            int index = 0;
            foreach (int value in values)
            {
                var name = Enum.GetName(type, value);
                items.Add(new SelectListItem { Text = name, Value = value.ToString(), Selected = index == 0 });
                index++;
            }
            return items;
        }
    }
}
