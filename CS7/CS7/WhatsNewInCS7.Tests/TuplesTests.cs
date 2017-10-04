using FluentAssertions;
using System;
using Xunit;

namespace WhatsNewInCS7.Tests
{
    public class TuplesTests : IDisposable
    {

        public TuplesTests()
        {
        }

        // Using an array, since InlineData does not accept
        [Theory]
        [InlineData("John", "Paul", "II", new string[] { "John", "Paul", "II" })]
        [InlineData("One", "Two", "Three", new string[] { "One", "Two", "Three" })]
        [InlineData("Angelina", "Jolie", "Pitt", new string[] { "Angelina", "Jolie", "Pitt" })]
        public void TestConvertToTupleMethods_Should_return_a_valid_Tuple(string firstName, string middleName, string familyName, string[] expected)
        {
            var actual1 = Tuples.ConvertToTuple(firstName, middleName, familyName);
            var actual2 = Tuples.ConvertToTupleOldStyle(firstName, middleName, familyName);

            expected[0].Should().Be(actual1.FirstName, $"The first name '{firstName}' was converted to {actual1.FirstName}, which did not match the expected value of {expected[0]}");
            expected[1].Should().Be(actual1.MiddleName, $"The middle name '{middleName}' was converted to {actual1.MiddleName}, which did not match the expected value of {expected[1]}");
            expected[2].Should().Be(actual1.FamilyName, $"The family name '{familyName}' was converted to {actual1.FamilyName}, which did not match the expected value of {expected[2]}");

            expected[0].Should().Be(actual2.Item1, $"The first name '{firstName}' was converted to {actual2.Item1}, which did not match the expected value of {expected[0]}");
            expected[1].Should().Be(actual2.Item2, $"The middle name '{middleName}' was converted to {actual2.Item2}, which did not match the expected value of {expected[1]}");
            expected[2].Should().Be(actual2.Item3, $"The family name '{familyName}' was converted to {actual2.Item3}, which did not match the expected value of {expected[2]}");
        }

        [Theory]
        [InlineData("John", "Smith", null)]
        [InlineData("Richard", "The", "Third")]
        [InlineData("One", "Two", null)]
        [InlineData("George", null, "Best")]
        public void TestConvertToTupleMethods_Should_throw_ArgumentException(string firstName, string middleName, string familyName)
        {
            Assert.Throws<ArgumentException>(() => Tuples.ConvertToTuple(firstName, familyName));
            Assert.Throws<ArgumentException>(() => Tuples.ConvertToTupleOldStyle(firstName, familyName));
        }

        [Fact]
        public void TestConvertToTuple_with_null_input_Should_throw_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Tuples.ConvertToTuple(null));
        }

        // Tearing down the test
        public void Dispose()
        {
        }
    }
}
