using System;

namespace SS.Events.Validation.Exceptions
{
    public class EventException : Exception
    {
        protected EventException(string message, System.FormatException innerException)
        : base(message, innerException)
        {
        }
    }
}
