using Smafac.Framework.Core.Services.Category;
using Smafac.Hrs.Employee.Domain;
using Smafac.Hrs.Employee.Repositories.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Employee.Services.Category
{
    class EmployeeCategoryInitialization : CategoryInitialization<EmployeeCategoryEntity>
    {
        public EmployeeCategoryInitialization(IEmployeeCategoryAddRepository categoryAddRepository,
                                        IEmployeeCategorySearchRepository categorySearchRepository
                                        )
        {
            base.CategoryAddRepository = categoryAddRepository;
            base.CategorySearchRepository = categorySearchRepository;
        }

        public override void Init(Guid subscriberId)
        {
            if (CategorySearchRepository.Any(subscriberId))
            {
                return;
            }
            IEnumerable<EmployeeCategoryEntity> categories = new List<EmployeeCategoryEntity> {
                new EmployeeCategoryEntity{
                    Name="正式员工",
                    SubscriberId=subscriberId
                },
                new EmployeeCategoryEntity{
                    Name="临时工",
                    SubscriberId=subscriberId
                }
            };
            CategoryAddRepository.AddEntities(categories);
        }
    }
}
