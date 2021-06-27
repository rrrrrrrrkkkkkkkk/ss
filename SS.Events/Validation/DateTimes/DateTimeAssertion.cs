using System;

namespace SS.Events.Validation.DateTimes
{
    internal class DateTimeAssertion: Assertion<DateTime>
    {
        public DateTimeAssertion(string value, string paramName) : base(ParseWithValidation(value, paramName), paramName)
        {
        }

        private static DateTime ParseWithValidation(string dateTime, string paramName)
        {
            try
            {
                return DateTime.ParseExact(dateTime, "yyyy-MM-ddTHH:mmzzz", null);
            }
            catch (FormatException exception)
            {
                throw new Exceptions.FormatException($"Invalid format for '{paramName}' property {dateTime}" ,exception);
            }
        }
    }
}
