using System;
using SS.Events.Validation.Exceptions;

namespace SS.App.Data
{
    public class EventDataException : Exception
    {
        public EventDataException(EventException eventException) : this(eventException.Message)
        {
        }

        public EventDataException(string message) : base(message)
        {
        }
    }
}
