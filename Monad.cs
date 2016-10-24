using System;
using System.CodeDom;
using System.Diagnostics;
using System.Linq.Expressions;

namespace ConsoleApplication1
{
    public abstract class Monad
    {
        protected abstract Monad Return(object val);
        protected abstract Monad Bind(Func<object, Monad> aToMb);

        /// <summary>
        /// Bind ma to aToMb, equivalent of Haskell's >>= 
        /// </summary>
        /// <param name="ma"></param>
        /// <param name="aToMb"></param>
        /// <returns></returns>
        public static Monad operator >=(Monad ma, Func<object, Monad> aToMb) => ma.Bind(aToMb);

        public static Monad operator <=(Monad ma, Func<object, Monad> aToMb)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Bind ma to mb, equivalent of Haskell's >>
        /// </summary>
        /// <param name="ma"></param>
        /// <param name="mb"></param>
        /// <returns></returns>
        public static Monad operator >(Monad ma, Monad mb) => ma.Bind(_ => mb);

        public static Monad operator <(Monad ma, Monad mb)
        {
            throw new NotImplementedException();
        }
    }
}