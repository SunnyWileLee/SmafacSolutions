﻿using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Domain.Entity
{
    public interface IEntityQueryer<TModel, TPageQueryModel>
        where TModel : SaasBaseModel
        where TPageQueryModel : PageQueryBaseModel
    {
        List<TModel> Query(TPageQueryModel query);
    }
}
