using Smafac.Framework.Core.Domain.Entity;
using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Domain.Pages
{
    public interface IPageQueryer<TModel, TPageQueryModel> : IEntityQueryer<TModel, TPageQueryModel>
        where TModel : SaasBaseModel
        where TPageQueryModel : PageQueryBaseModel
    {
        PageModel<TModel> QueryPage(TPageQueryModel query);
    }
}
