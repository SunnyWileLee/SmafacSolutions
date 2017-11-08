using Smafac.Framework.Core.Domain.CategoryProperty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Smafac.Hrs.Salary.Repositories;
using Smafac.Hrs.Salary.Repositories.PropertyValue;

namespace Smafac.Hrs.Salary.Domain.CategoryProperty
{
    class SalaryCategoryPropertyBindTrigger : CategoryPropertyBindTrigger<SalaryEntity, SalaryCategoryEntity, SalaryPropertyEntity, SalaryPropertyValueEntity>,
                                            ISalaryCategoryPropertyBindTrigger
    {
        public SalaryCategoryPropertyBindTrigger(ISalarySearchRepository goodsSearchRepository,
                                                ISalaryPropertyValueSetRepository goodsPropertyValueSetRepository)
        {
            base.EntitySearchRepository = goodsSearchRepository;
            base.AssociationValueAddRepository = goodsPropertyValueSetRepository;
        }

        protected override void ModifyValue(SalaryPropertyValueEntity value, Guid goodsId, SalaryPropertyEntity property)
        {
            base.ModifyValue(value, goodsId, property);
            value.SalaryId = goodsId;
        }

        protected override Expression<Func<SalaryEntity, bool>> CreateEntityPredicate(SalaryCategoryEntity category)
        {
            return goods => goods.CategoryId == category.Id;
        }
    }
}
