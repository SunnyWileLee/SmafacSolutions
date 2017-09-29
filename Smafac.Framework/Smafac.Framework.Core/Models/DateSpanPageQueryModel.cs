using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Models
{
    public abstract class DateSpanPageQueryModel : PageQueryBaseModel
    {
        [Display(Name = "开始日期")]
        public virtual DateTime BeginDate { get; set; }
        [Display(Name = "结束日期")]
        public virtual DateTime EndDate { get; set; }

        public DateSpanPageQueryModel()
        {
            BeginDate = DateTime.Now.Date;
            EndDate = DateTime.Now.Date;
        }

        public override Expression CreateExpressionBody(Expression param)
        {
            return Expression.AndAlso(CreateBeginDateExpression(param), CreateEndDateExpression(param));
        }

        protected Expression CreateBeginDateExpression(Expression param)
        {
            var left = Expression.Property(param, DateColumn);
            var right = Expression.Constant(BeginDate.Date);
            return Expression.GreaterThanOrEqual(left, right);
        }

        protected Expression CreateEndDateExpression(Expression param)
        {
            var left = Expression.Property(param, DateColumn);
            var right = Expression.Constant(EndDate.Date.AddDays(1).AddSeconds(-1));
            return Expression.LessThanOrEqual(left, right);
        }

        protected abstract string DateColumn
        {
            get;
        }
    }
}
