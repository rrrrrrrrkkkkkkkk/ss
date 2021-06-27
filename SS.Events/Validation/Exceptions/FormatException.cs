namespace SS.Events.Validation.Exceptions
{
    public class FormatException : EventException
    {
        public FormatException(string message, System.FormatException innerException) : base(message, innerException)
        {
        }
    }
}
