using System;
using SS.Events.Validation;
using SS.Events.Validation.Strings;

namespace SS.Events
{
    public class Event
    {
        public Event(string name, string description, string start, string end)
            : this(
                name,
                description,
                start.Assert(nameof(start)).IsDateTime(),
                end.Assert(nameof(end)).IsDateTime())
        {
        }

        private Event(string name, string description, DateTime start, DateTime end)
        {
            Name = name.Assert(nameof(name)).NotNull().NotEmpty().MaxLength(32);
            Description = description.Assert(nameof(description)).NotNull().NotEmpty().MaxLength(255);
            Start = start;
            End = end;
        }

        public string Name { get; }
        public string Description { get; }
        public DateTime Start { get; }
        public DateTime End { get; }
    }
}
