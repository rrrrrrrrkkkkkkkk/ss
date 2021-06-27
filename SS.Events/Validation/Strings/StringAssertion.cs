using System;
using SS.Events.Validation.DateTimes;
using SS.Events.Validation.Exceptions;

namespace SS.Events.Validation.Strings
{
    internal class StringAssertion : Assertion<string>
    {
        public StringAssertion(string value, string paramName) : base(value, paramName)
        {
        }

        public StringAssertion NotNull() => this.Assert(Value != null, () => new ArgumentNullException(ParamName));

        public StringAssertion NotEmpty() => this.Assert(!string.IsNullOrEmpty(Value), () => new ArgumentEmptyException(ParamName));

        public StringAssertion MaxLength(int maxLength) => this.Assert(Value?.Length <= maxLength,
            () => new ArgumentMaxLengthExceeded(ParamName, Value, maxLength));

        public DateTimeAssertion IsDateTime() => new DateTimeAssertion(Value, ParamName);
    }

    internal static class StringExtensions
    {
        public static StringAssertion Assert(this string value, string paramName) => new StringAssertion(value, paramName);
    }
}
