using Smafac.Framework.Core.Domain.CategoryProperty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Smafac.Hrs.Employee.Repositories;
using Smafac.Hrs.Employee.Repositories.PropertyValue;

namespace Smafac.Hrs.Employee.Domain.CategoryProperty
{
    class EmployeeCategoryPropertyBindTrigger : CategoryPropertyBindTrigger<EmployeeEntity, EmployeeCategoryEntity, EmployeePropertyEntity, EmployeePropertyValueEntity>,
                                            IEmployeeCategoryPropertyBindTrigger
    {
        public EmployeeCategoryPropertyBindTrigger(IEmployeeSearchRepository searchRepository,
                                                IEmployeePropertyValueSetRepository propertyValueSetRepository)
        {
            base.EntitySearchRepository = searchRepository;
            base.AssociationValueAddRepository = propertyValueSetRepository;
        }

        protected override void ModifyValue(EmployeePropertyValueEntity value, Guid goodsId, EmployeePropertyEntity property)
        {
            base.ModifyValue(value, goodsId, property);
            value.EmployeeId = goodsId;
        }

        protected override Expression<Func<EmployeeEntity, bool>> CreateEntityPredicate(EmployeeCategoryEntity category)
        {
            return goods => goods.CategoryId == category.Id;
        }
    }
}
