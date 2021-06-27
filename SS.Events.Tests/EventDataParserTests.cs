using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace SS.Events.Tests
{
    public class EventDataParserTests
    {
        private const string ValidDateTime = "2021-06-01T14:15+01:00";
        private EventDataParser _sut;

        [OneTimeSetUp]
        public void SetUp() => _sut = new EventDataParser();

        [TestCase("a;b;"+ ValidDateTime + ";"+ ValidDateTime +";")]
        public async Task Parse_ShouldSplitBySemicolon(string input)
        {
            var events = await _sut.ParseAsync(new StringStream(input), default).ToListAsync();
            events.Should().HaveCount(4);
        }
    }

    public class StringStream : MemoryStream
    {
        public StringStream(string content) : base(Encoding.UTF8.GetBytes(content))
        {
        }
    }
}
