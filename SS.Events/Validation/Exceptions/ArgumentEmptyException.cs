using System;

namespace SS.Events.Validation.Exceptions
{
    internal class ArgumentEmptyException : ArgumentException
    {
        public ArgumentEmptyException(string paramName) : base($"Value cannot be empty: {paramName}", paramName)
        {
        }
    }
}