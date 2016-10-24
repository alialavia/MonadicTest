using System;

namespace ConsoleApplication1
{
    public class IsNothingException : Exception
    {
        public override string Message => "Cannot execute FromJust on Nothing.";
    }

    public class Maybe : Monad
    {
        public Maybe(object value)
        {
            _value = value;
        }

        public Maybe()
        {
            _value = _nothing;
        }

        public static Maybe Just(object value) => new Maybe(value);

        public Maybe Bind(Func<object, Maybe> aToMb)
        {
            return (Maybe)Bind(o => (Monad)aToMb(o));
        }

        public object FromJust()
        {
            if (IsJust)
                return _value;
            throw new IsNothingException();
        }

        public object FromMaybe(object defaultVal) => MaybeFunc(defaultVal, o => o);

        public object MaybeFunc(object defaultVal, Func<object, object> func)
        {
            return IsNothing ? defaultVal : func(FromJust());
        }

        public override string ToString()
        {
            return IsNothing ? "Nothing" : $"Just {_value}";
        }

        protected override Monad Bind(Func<object, Monad> aToMb)
        {
            return IsNothing ? Nothing : aToMb(FromJust());
        }

        protected override Monad Return(object val)
        {
            return new Maybe(val);
        }

        public bool IsJust => !IsNothing;

        public bool IsNothing => _value == _nothing;

        public static readonly Maybe Nothing = new Maybe();

        private readonly object _nothing = new object();

        private readonly object _value;
    }
}