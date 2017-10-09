using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Driver
{
    public interface ICommandPipe
    {
        TResult Execute<TParameter, TResult>(Expression<Func<TParameter, TResult>> expression, TParameter paras);
        TResult Execute<TResult>(Expression<Func<TResult>> expression);
    }
}
