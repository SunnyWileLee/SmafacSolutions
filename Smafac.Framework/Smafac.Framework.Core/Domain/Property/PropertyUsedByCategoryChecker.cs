using Smafac.Framework.Core.Models;
using Smafac.Framework.Core.Repositories.CategoryProperty;
using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Domain.Property
{
    public abstract class PropertyUsedByCategoryChecker<TCategory, TProperty> : IPropertyUsedChecker<TProperty>
        where TCategory : CategoryEntity
         where TProperty : PropertyEntity

    {
        public ICategoryPropertySearchRepository<TCategory, TProperty> CategoryPropertySearchRepository { get; protected set; }

        public virtual bool Check(TProperty column)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            return CategoryPropertySearchRepository.Any(subscriberId, column.Id);
        }
    }
}
