using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Models
{
    public enum CompareType
    {
        GreatThan = 0,
        GreatEqual = 1,
        LessThan = 2,
        LessEqual = 3,
        Equal = 4,
        Like = 5,
        StartWith = 6,
        EndWith = 7,
        NotEqual = 8
    }

    public class QueryPropertyAttribute:Attribute
    {
        private CompareType _compareType;
        private bool _allowDefault;
        public QueryPropertyAttribute()
        {
            _compareType = Models.CompareType.Equal;
            _allowDefault = false;
        }
        public string Name { get; set; }
        public CompareType Compare
        {
            get
            {
                return _compareType;
            }
            set
            {
                _compareType = value;
            }
        }
        public bool AllowDefault
        {
            get
            {
                return _allowDefault;
            }
            set
            {
                _allowDefault = value;
            }
        }


        public Expression CreateExpression(Expression param, object value)
        {
            var left = Expression.Property(param, Name);
            var right = Expression.Constant(value);
            switch (Compare)
            {
                case CompareType.Equal:
                    {
                        return Expression.Equal(left, right);
                    }
                case CompareType.GreatThan:
                    {
                        return Expression.GreaterThan(left, right);
                    }
                case CompareType.GreatEqual:
                    {
                        return Expression.GreaterThanOrEqual(left, right);
                    }
                case CompareType.LessThan:
                    {
                        return Expression.LessThan(left, right);
                    }
                case CompareType.LessEqual:
                    {
                        return Expression.LessThanOrEqual(left, right);
                    }
                case CompareType.NotEqual:
                    {
                        return Expression.NotEqual(left, right);
                    }
                case CompareType.Like:
                    {
                        var method = typeof(string).GetMethod("Contains");
                        return Expression.Call(left, method, right);
                    }
                case CompareType.StartWith:
                    {
                        var method = typeof(string).GetMethods().Where(s => s.Name == "StartsWith").First(s => s.GetParameters().Count() == 1);
                        return Expression.Call(left, method, right);
                    }
                case CompareType.EndWith:
                    {
                        var method = typeof(string).GetMethods().Where(s => s.Name == "EndWith").First(s => s.GetParameters().Count() == 1);
                        return Expression.Call(left, method, right);
                    }
                default:
                    {
                        throw new ArgumentOutOfRangeException(Compare.ToString() + "类型不受支持");
                    }
            }
        }
    }
}
