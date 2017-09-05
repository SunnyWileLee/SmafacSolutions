﻿using Smafac.Framework.Core.Domain;
using Smafac.Framework.Core.Repositories.CustomizedColumn;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Repositories.Property
{
    public abstract class PropertyDeleteRepository<TContext, TProperty> : CustomizedColumnDeleteRepository<TContext, TProperty>, IPropertyDeleteRepository<TProperty>
         where TProperty : PropertyEntity
         where TContext : DbContext
    {

    }
}
