using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Smafac.Presentation.Domain
{
    public interface IPropertyTypeProvider
    {
        IEnumerable<SelectListItem> Provide();
    }
}
