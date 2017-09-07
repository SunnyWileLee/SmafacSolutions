using Smafac.Framework.Core.Applications;
using Smafac.Framework.Core.Models;
using Smafac.Framework.Core.Repositories.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Domain.InitDatas
{
    public abstract class InitCategory<TCategory> : IInitDatas
        where TCategory : CategoryEntity
    {
        public virtual ICategoryAddRepository<TCategory> CategoryAddRepository
        {
            get; protected set;
        }

        public void Init()
        {
            var category = CreateDefaultCategory();
            CategoryAddRepository.AddEntity(category);
        }

        protected virtual TCategory CreateDefaultCategory()
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var category = Activator.CreateInstance<TCategory>();
            category.SubscriberId = subscriberId;
            category.Name = "默认分类";
            return category;
        }
    }
}
