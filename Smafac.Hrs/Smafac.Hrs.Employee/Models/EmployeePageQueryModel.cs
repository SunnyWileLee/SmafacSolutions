using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Smafac.Hrs.Employee.Models
{
    public class EmployeePageQueryModel : DateSpanPageQueryModel
    {
        [Display(Name = "分类")]
        [QueryProperty(Compare = CompareType.Equal)]
        public Guid CategoryId { get; set; }
        [Display(Name = "关键字")]
        public string KeyWord { get; set; }

        protected override string DateColumn => "EmployeeDate";

        public override Expression CreateExpressionBody(Expression param)
        {
            if (string.IsNullOrEmpty(KeyWord))
            {
                return base.CreateExpressionBody(param);
            }
            var properties = new List<string> { "Name", "Identity", "Phone" };
            return CreateExpressionBody(param, properties, this.KeyWord);
        }

        private Expression CreateExpressionBody(Expression param, IEnumerable<string> properties, string keyword)
        {
            var method = typeof(string).GetMethod("Contains");
            Expression body = null;
            foreach (var property in properties)
            {
                var left = Expression.Property(param, property);
                var expression = Expression.Call(left, method, Expression.Constant(keyword));
                if (body == null)
                {
                    body = expression;
                }
                else
                {
                    body = Expression.OrElse(body, expression);
                }
            }
            return body;
        }
    }
}
