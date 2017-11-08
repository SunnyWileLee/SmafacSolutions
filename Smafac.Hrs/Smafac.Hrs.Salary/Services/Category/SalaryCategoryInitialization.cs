using Smafac.Framework.Core.Services.Category;
using Smafac.Hrs.Salary.Domain;
using Smafac.Hrs.Salary.Repositories.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Salary.Services.Category
{
    class SalaryCategoryInitialization : CategoryInitialization<SalaryCategoryEntity>
    {
        public SalaryCategoryInitialization(ISalaryCategoryAddRepository goodsCategoryAddRepository,
                                        ISalaryCategorySearchRepository goodsCategorySearchRepository
                                        )
        {
            base.CategoryAddRepository = goodsCategoryAddRepository;
            base.CategorySearchRepository = goodsCategorySearchRepository;
        }

        public override void Init(Guid subscriberId)
        {
            if (CategorySearchRepository.Any(subscriberId))
            {
                return;
            }
            IEnumerable<SalaryCategoryEntity> categories = new List<SalaryCategoryEntity> {
                new SalaryCategoryEntity{
                    Name="工资",
                    SubscriberId=subscriberId
                },
                new SalaryCategoryEntity{
                    Name="奖金",
                    SubscriberId=subscriberId
                },
                new SalaryCategoryEntity{
                    Name="报销",
                    SubscriberId=subscriberId
                },
                new SalaryCategoryEntity{
                    Name="补贴",
                    SubscriberId=subscriberId
                }
            };
            CategoryAddRepository.AddEntities(categories);
        }
    }
}
