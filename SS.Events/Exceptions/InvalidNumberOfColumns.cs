namespace SS.Events.Exceptions
{
    public class InvalidNumberOfColumns : ParsingException
    {
        public InvalidNumberOfColumns(int numberOfColumns, int expectedNumberOfColumns, string line) : base(
            $"Invalid number of columns. Expecting {expectedNumberOfColumns}, found {numberOfColumns} in '{line}'")
        {
        }
    }
}
