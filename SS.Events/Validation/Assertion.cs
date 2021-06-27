using System;

namespace SS.Events.Validation
{
    internal abstract class Assertion
    { }

    internal abstract class Assertion<T> : Assertion
    {
        protected T Value { get; }
        protected string ParamName { get; }

        protected Assertion(T value, string paramName)
        {
            Value = value;
            ParamName = paramName;
        }

        public static implicit operator T(Assertion<T> assertion) => assertion.Value;
    }

    internal static class AssertionExtensions
    {
        public static TAssertion Assert<TAssertion>(this TAssertion assertion, bool condition, Func<Exception> exceptionFactory)
        where TAssertion : Assertion
        {
            if (!condition)
            {
                throw exceptionFactory();
            }

            return assertion;
        }
    }
}
