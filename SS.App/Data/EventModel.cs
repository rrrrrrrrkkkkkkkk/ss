using System;

namespace SS.App.Data
{
    public class EventModel
    {
        public string Name { get; internal set; }
        public string Description { get; internal set; }
        public DateTime Start { get; internal set; }
        public DateTime End { get; internal set; }
    }
}
