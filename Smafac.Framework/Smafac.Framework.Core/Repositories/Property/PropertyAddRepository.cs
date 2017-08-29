﻿using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Repositories.Property
{
    public abstract class PropertyAddRepository<TContext, TProperty> : EntityAddRepository<TContext, TProperty>, IPropertyAddRepository<TProperty>
         where TProperty : PropertyEntity
         where TContext : DbContext
    {

    }
}