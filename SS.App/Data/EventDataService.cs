using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Microsoft.AspNetCore.Components.Forms;
using SS.Events;
using SS.Events.Validation.Exceptions;

namespace SS.App.Data
{
    public class EventDataService
    {
        private readonly EventDataParser _parser;

        public EventDataService(EventDataParser parser) => _parser = parser;

        public async IAsyncEnumerable<EventModel> LoadEventsAsync(IBrowserFile file, [EnumeratorCancellation]CancellationToken cancellationToken)
        {
            if (file.Size > 3 * 1024 * 1024)
            {
                throw new EventDataException("Max file size (3MB) exceeded.");
            }

            await using var content = file.OpenReadStream();
            var enumerator = _parser.ParseAsync(content, cancellationToken).GetAsyncEnumerator(cancellationToken);

            while (true)
            {
                try
                {
                    if (!await enumerator.MoveNextAsync())
                    {
                        yield break;
                    }
                }
                catch (EventException ex)
                {
                    throw Map(ex);
                }

                yield return Map(enumerator.Current);
            }
        }

        private Exception Map(EventException eventException) => new EventDataException(eventException);

        private EventModel Map(Event e) => new()
            {Name = e.Name, Description = e.Description, Start = e.Start, End = e.End};
    }
}
