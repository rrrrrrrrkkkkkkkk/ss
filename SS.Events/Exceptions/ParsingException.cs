using System;

namespace SS.Events.Exceptions
{
    public abstract class ParsingException : Exception
    {
        protected ParsingException(string message) : base(message)
        {
        }
    }
}
