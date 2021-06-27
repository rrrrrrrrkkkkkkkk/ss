using System;

namespace SS.Events.Validation.Exceptions
{
    internal class ArgumentMaxLengthExceeded : ArgumentException
    {
        public ArgumentMaxLengthExceeded(string paramName, string value, int maxLength) :
            base($"{paramName} should not be longer than {maxLength}, is {value?.Length}", paramName)
        {
        }
    }
}