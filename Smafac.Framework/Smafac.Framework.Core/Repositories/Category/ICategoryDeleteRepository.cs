﻿using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Repositories.Category
{
    public interface ICategoryDeleteRepository<TCategory> : IEntityDeleteRepository<TCategory>
        where TCategory : CategoryEntity
    {
    }
}
