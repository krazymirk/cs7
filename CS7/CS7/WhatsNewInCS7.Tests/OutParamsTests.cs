using FluentAssertions;
using System;
using Xunit;

namespace WhatsNewInCS7.Tests
{
    public class OutParamsTests : IDisposable
    {
        private readonly int? _empty;

        public OutParamsTests()
        {
            _empty = new int?();
        }

        [Theory]
        [InlineData("6", 6)]
        [InlineData("-5", -5)]
        [InlineData("0", 0)]
        [InlineData("19", 19)]
        [InlineData("-764230", -764230)]
        [InlineData("blah, blah - obviously not an int", null)]
        public void TestTryConvertToInt_Should_return_an_int_or_nothing(string expression, int? expected)
        {
            var actual = OutParams.TryConvertToInt(expression);
            expected.Should().Be(actual, $"The expression '{expression}' was converted to {actual}, which did not match the expected value of {expected}");
        }

        // Tearing down the test
        public void Dispose()
        {
        }
    }
}
