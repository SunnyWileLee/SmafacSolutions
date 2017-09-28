using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Applications.Category
{
    public interface ICategoryInitialization<TCategory> : IDataInitialization
        where TCategory : CategoryEntity
    {
    }
}
