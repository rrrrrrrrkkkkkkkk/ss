using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using CsvHelper;
using CsvHelper.Configuration;
using SS.Events.Exceptions;

namespace SS.Events
{
    public class EventDataParser
    {
        public async IAsyncEnumerable<Event> ParseAsync(Stream stream, [EnumeratorCancellation]CancellationToken cancellationToken)
        {
            using var parser = CreateParser(stream);

            while (await parser.ReadAsync())
            {
                cancellationToken.ThrowIfCancellationRequested();

                var record = parser.Record;
                var numberOfTokens = string.IsNullOrEmpty(record[record.Length - 1]) ? record.Length -1 : record.Length;

                const int expectedNumberOfTokens = 4;
                if (numberOfTokens != expectedNumberOfTokens)
                {
                    throw new InvalidNumberOfColumns(numberOfTokens, expectedNumberOfTokens, parser.RawRecord);
                }
                
                var name = record[0];
                var description = record[1].TrimStart();
                var start = record[2].TrimStart();
                var end = record[3].TrimStart();

                yield return new Event(name, description, start, end);
            }
        }

        private CsvParser CreateParser(Stream stream) =>
            new CsvParser(new StreamReader(stream),
                new CsvConfiguration(CultureInfo.CurrentCulture)
                { LeaveOpen = true, Delimiter = ";", HasHeaderRecord = false });
    }
}
