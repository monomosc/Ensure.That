using System;
using EnsureThat.Resources;
using System.Text.RegularExpressions;
using Xunit;

namespace EnsureThat.Tests.UnitTests
{
    public class EnsureStringParamTests : UnitTestBase
    {
        private const string ParamName = "test";

        [Fact]
        public void IsNotNull_WhenStringIsNull_ThrowsArgumentNullException()
        {
            string value = null;

            var ex = Assert.Throws<ArgumentNullException>(
                () => Ensure.That(value, ParamName).IsNotNull());

            Assert.Equal(ParamName, ex.ParamName);
            Assert.Equal(ExceptionMessages.EnsureExtensions_IsNotNull
                + "\r\nParameter name: test",
                ex.Message);
        }

        [Fact]
        public void IsNotNull_WhenStringIsNotNull_ReturnsPassedString()
        {
            var value = string.Empty;

            var returnedValue = Ensure.That(value, ParamName).IsNotNull();

            Assert.Equal(ParamName, returnedValue.Name);
            Assert.Equal(value, returnedValue.Value);
        }

        [Fact]
        public void IsNotNullOrEmpty_WhenStringIsNull_ThrowsArgumentException()
        {
            string value = null;

            var ex = Assert.Throws<ArgumentException>(
                () => Ensure.That(value, ParamName).IsNotNullOrEmpty());

            Assert.Equal(ParamName, ex.ParamName);
            Assert.Equal(ExceptionMessages.EnsureExtensions_IsNotNullOrEmpty
                + "\r\nParameter name: test",
                ex.Message);
        }

        [Fact]
        public void IsNotNullOrEmpty_WhenStringIsEmpty_ThrowsArgumentException()
        {
            string value = string.Empty;

            var ex = Assert.Throws<ArgumentException>(
                () => Ensure.That(value, ParamName).IsNotNullOrEmpty());

            Assert.Equal(ParamName, ex.ParamName);
            Assert.Equal(ExceptionMessages.EnsureExtensions_IsNotNullOrEmpty
                + "\r\nParameter name: test",
                ex.Message);
        }

        [Fact]
        public void IsNotNullOrEmpty_WhenStringIsNotNullOrEmpty_ReturnsPassedString()
        {
            var value = " ";

            var returnedValue = Ensure.That(value, ParamName).IsNotNull();

            Assert.Equal(ParamName, returnedValue.Name);
            Assert.Equal(value, returnedValue.Value);
        }

        [Fact]
        public void IsNotNullOrWhiteSpace_WhenStringIsNull_ThrowsArgumentNullException()
        {
            string value = null;

            var ex = Assert.Throws<ArgumentException>(
                () => Ensure.That(value, ParamName).IsNotNullOrWhiteSpace());

            Assert.Equal(ParamName, ex.ParamName);
            Assert.Equal(ExceptionMessages.EnsureExtensions_IsNotNullOrWhiteSpace
                + "\r\nParameter name: test",
                ex.Message);
        }

        [Fact]
        public void IsNotNullOrWhiteSpace_WhenStringIsEmpty_ThrowsArgumentNullException()
        {
            string value = string.Empty;

            var ex = Assert.Throws<ArgumentException>(
                () => Ensure.That(value, ParamName).IsNotNullOrWhiteSpace());

            Assert.Equal(ParamName, ex.ParamName);
            Assert.Equal(ExceptionMessages.EnsureExtensions_IsNotNullOrWhiteSpace
                + "\r\nParameter name: test",
                ex.Message);
        }

        [Fact]
        public void IsNotNullOrWhiteSpace_WhenStringIsWhiteSpace_ThrowsArgumentNullException()
        {
            string value = " ";

            var ex = Assert.Throws<ArgumentException>(
                () => Ensure.That(value, ParamName).IsNotNullOrWhiteSpace());

            Assert.Equal(ParamName, ex.ParamName);
            Assert.Equal(ExceptionMessages.EnsureExtensions_IsNotNullOrWhiteSpace
                + "\r\nParameter name: test",
                ex.Message);
        }

        [Fact]
        public void IsNotNullOrWhiteSpace_WhenStringHasValue_ReturnsPassedString()
        {
            var value = "delta";

            var returnedValue = Ensure.That(value, ParamName).IsNotNullOrWhiteSpace();

            Assert.Equal(ParamName, returnedValue.Name);
            Assert.Equal(value, returnedValue.Value);
        }

        [Fact]
        public void HasLengthBetween_WhenStringIsNull_ThrowsArgumentNullException()
        {
            string value = null;

            var ex = Assert.Throws<ArgumentException>(
                () => Ensure.That(value, ParamName).HasLengthBetween(1, 2));

            Assert.Equal(ParamName, ex.ParamName);
            Assert.Equal(ExceptionMessages.EnsureExtensions_IsNotNullOrEmpty
                + "\r\nParameter name: test",
                ex.Message);
        }

        [Fact]
        public void HasLengthBetween_WhenStringIs1CharacterLong_ThrowsArgumentException()
        {
            string value = "a";

            var ex = Assert.Throws<ArgumentException>(
                () => Ensure.That(value, ParamName).HasLengthBetween(2, 4));

            Assert.Equal(ParamName, ex.ParamName);
            Assert.Equal(String.Format(ExceptionMessages.EnsureExtensions_IsNotInRange_ToShort, 2, 4, 1)
                + "\r\nParameter name: test",
                ex.Message);
        }

        [Fact]
        public void HasLengthBetween_WhenStringIs5CharactersLong_ThrowsArgumentException()
        {
            string value = "abcde";

            var ex = Assert.Throws<ArgumentException>(
                () => Ensure.That(value, ParamName).HasLengthBetween(2, 4));

            Assert.Equal(ParamName, ex.ParamName);
            Assert.Equal(String.Format(ExceptionMessages.EnsureExtensions_IsNotInRange_ToLong, 2, 4, 5)
                + "\r\nParameter name: test",
                ex.Message);
        }

        [Fact]
        public void HasLengthBetween_WhenStringIs2CharactersLong_ReturnsPassedString()
        {
            var value = "ab";

            var returnedValue = Ensure.That(value, ParamName).HasLengthBetween(2, 4);

            Assert.Equal(ParamName, returnedValue.Name);
            Assert.Equal(value, returnedValue.Value);
        }

        [Fact]
        public void HasLengthBetween_WhenStringIs4CharactersLong_ReturnsPassedString()
        {
            var value = "abcd";

            var returnedValue = Ensure.That(value, ParamName).HasLengthBetween(2, 4);

            Assert.Equal(ParamName, returnedValue.Name);
            Assert.Equal(value, returnedValue.Value);
        }

        [Fact]
        public void Matches_WhenUrlStringMatchesStringPattern_ThrowsArgumentException()
        {
            var value = @"incorrect";
            var match = @"(?<Protocol>\w+):\/\/(?<Domain>[\w@][\w.:@]+)\/?[\w\.?=%&=\-@/$,]*";
            var ex = Assert.Throws<ArgumentException>(
                () => Ensure.That(value, ParamName).Matches(match));

            Assert.Equal(ParamName, ex.ParamName);
            Assert.Equal(String.Format(ExceptionMessages.EnsureExtensions_NoMatch, value, match)
                + "\r\nParameter name: test",
                ex.Message);
        }

        [Fact]
        public void Matches_WhenUrlStringMatchesRegexPattern_ThrowsArgumentException()
        {
            var value = @"incorrect";
            var match = new Regex(@"(?<Protocol>\w+):\/\/(?<Domain>[\w@][\w.:@]+)\/?[\w\.?=%&=\-@/$,]*");
            var ex = Assert.Throws<ArgumentException>(
                () => Ensure.That(value, ParamName).Matches(match));

            Assert.Equal(ParamName, ex.ParamName);
            Assert.Equal(String.Format(ExceptionMessages.EnsureExtensions_NoMatch, value, match)
                + "\r\nParameter name: test",
                ex.Message);
        }

        [Fact]
        public void Matches_WhenUrlStringMatchesStringPattern_ReturnsPassedString()
        {
            var value = @"http://google.com:8080";
            var match = @"(?<Protocol>\w+):\/\/(?<Domain>[\w@][\w.:@]+)\/?[\w\.?=%&=\-@/$,]*";
            var returnedValue = Ensure.That(value, ParamName).Matches(match);
            Assert.Equal(ParamName, returnedValue.Name);
            Assert.Equal(value, returnedValue.Value);
        }

        [Fact]
        public void Matches_WhenUrlStringMatchesRegexPattern_ReturnsPassedString()
        {
            var value = @"http://google.com:8080";
            var match = new Regex(@"(?<Protocol>\w+):\/\/(?<Domain>[\w@][\w.:@]+)\/?[\w\.?=%&=\-@/$,]*");
            var returnedValue = Ensure.That(value, ParamName).Matches(match);
            Assert.Equal(ParamName, returnedValue.Name);
            Assert.Equal(value, returnedValue.Value);
        }
    }
}