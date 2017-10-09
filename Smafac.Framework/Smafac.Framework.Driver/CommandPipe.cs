using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Driver
{
    public abstract class CommandPipe : ICommandPipe
    {
        public virtual PipeStartHandler StartHandler { get; set; }
        public virtual PipeEndHandler EndHandler { get; set; }

        protected virtual List<ICommandHandler> Handlers { get; set; }

        public virtual TResult Execute<TParameter, TResult>(Expression<Func<TParameter, TResult>> expression, TParameter paras)
        {
            return expression.Compile().Invoke(paras);
        }

        public TResult Execute<TResult>(Expression<Func<TResult>> expression)
        {
            var body = expression.Body as MethodCallExpression;
            var method = body.Method;
            return expression.Compile().Invoke();
        }
    }
}
