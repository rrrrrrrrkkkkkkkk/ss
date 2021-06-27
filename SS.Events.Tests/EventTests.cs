using System;
using FluentAssertions;
using NUnit.Framework;

namespace SS.Events.Tests
{
    public class EventTests
    {
        private const string ValidDateTime = "2021-06-01T14:15+01:00";
        private static string[] _nullOrEmptyValues = { null, string.Empty };
        private static string[] _invalidDateTimes = { "2021-06-01T14:15", "2021/06/01 14:15" };

        [Test]
        public void Ctor_ShouldCreateInstance() =>
            new Event("name", "description", ValidDateTime, ValidDateTime)
                .Should().NotBeNull();

        #region name
        [TestCase(1)]
        [TestCase(32)]
        public void Ctor_ShouldCreateInstance_WithCorrectProperty(int nameLength) =>
            new Event(new string('x', nameLength), "test", ValidDateTime, ValidDateTime)
                .Name.Should().Be(new string('x', nameLength));

        [Test]
        public void Ctor_ShouldFail_WhenNameNull() =>
            this.Invoking(_ => new Event(null, "test", ValidDateTime, ValidDateTime)).Should().Throw<ArgumentException>()
                .Where(e => e.ParamName == "name");

        [TestCase(0)]
        [TestCase(33)]
        public void Ctor_ShouldFail_WhenNameLengthInvalid(int nameLength) => this
            .Invoking(_ => new Event(new string('x', nameLength), "desc", ValidDateTime, ValidDateTime))
            .Should().Throw<ArgumentException>()
            .Where(e => e.ParamName == "name");

        [TestCaseSource(nameof(_nullOrEmptyValues))]
        public void Ctor_ShouldThrow_WhenNoName(string name) =>
            this
            .Invoking(_ => new Event(name, "test", ValidDateTime, ValidDateTime))
            .Should().Throw<ArgumentException>().Where(e => e.ParamName == "name");
        #endregion name

        #region description

        [TestCase(1)]
        [TestCase(255)]
        public void Ctor_ShouldCreateInstance_WithValidDescription(int descriptionLength) =>
            new Event("name", new string('x', descriptionLength), ValidDateTime, ValidDateTime)
                .Description.Should().Be(new string('x', descriptionLength));

        [Test]
        public void Ctor_ShouldThrow_WhenDescriptionNull() => this
            .Invoking(_ => new Event("description", null, ValidDateTime, ValidDateTime))
            .Should().Throw<ArgumentNullException>()
            .Where(e => e.ParamName == "description");

        [TestCase(0)]
        [TestCase(256)]
        public void Ctor_ShouldThrow_WhenDesriptionLengthInvalid(int descriptionLength) =>
            this.Invoking(_ => new Event("name", new string('x', descriptionLength), ValidDateTime, ValidDateTime))
                .Should().Throw<ArgumentException>()
                .Where(e => e.ParamName == "description");
        #endregion desription

        #region start
        [TestCase(ValidDateTime)]
        public void Ctor_ShouldCreateInstance_WhenStartFormatValid(string start) =>
            new Event("name", "desc", start, ValidDateTime);

        [TestCaseSource(nameof(_invalidDateTimes))]
        public void Ctor_ShouldThrow_WhenStartFormatInvalid(string start) =>
            this.Invoking(_ => new Event("name", "desc", start, ValidDateTime))
                .Should().Throw<FormatException>();
        #endregion start
    }
}

