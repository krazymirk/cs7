// Copyright 2017 Krasimir Kostadinov. All rights reserved. Use of this source code is governed by the Apache License 2.0, as found on https://www.apache.org/licenses/LICENSE-2.0

using Xunit;
using FluentAssertions;
using System.Linq;
using System;

namespace WhatsNewInCS7.Tests
{
    public class PatternMatchingTests
    {
        private void AssertNameTuple(string firstName, string middleName, string familyName, (string FirstName, string MiddleName, string FamilyName) actualTuple)
        {
            actualTuple.FirstName.Should().Be(firstName, $"The first name '{firstName}' was converted to {actualTuple.FirstName}, which does not match the expected");
            actualTuple.MiddleName.Should().Be(middleName, $"The middle name '{middleName}' was converted to {actualTuple.MiddleName}, which does not match the expected");
            actualTuple.FamilyName.Should().Be(familyName, $"The family name '{familyName}' was converted to {actualTuple.FamilyName}, which does not match the expected");
        }

        [Theory]
        [InlineData("John", "Paul", "II")]
        [InlineData("One", "Two", "Three")]
        [InlineData("Angelina", "Jolie", "Pitt")]
        public void TestConvertToTuple_with_array_and_IEnnumerable_Should_return_a_valid_Tuple(string firstName, string middleName, string familyName)
        {
            var actualTupleWithArray = PatternMatching.ConvertTotTuple(new string[] { firstName, middleName, familyName });
            var actualTupleWithIEnnumarable = PatternMatching.ConvertTotTuple((new string[] { firstName, middleName, familyName }).ToList());
            AssertNameTuple(firstName, middleName, familyName, actualTupleWithArray);
            AssertNameTuple(firstName, middleName, familyName, actualTupleWithIEnnumarable);
        }

        [Theory]
        [InlineData("John")]
        [InlineData("One")]
        [InlineData("Angelina")]
        public void TestConvertToTuple_with_string_Should_return_a_valid_Tuple(string firstName)
        {
            var actualTupleWithString = PatternMatching.ConvertTotTuple(firstName);
            AssertNameTuple(firstName, null, null, actualTupleWithString);
        }

        [Fact]
        public void TestConvertToTuple_with_array_Should_throw_ArgumentException()
        {
            Assert.Throws<ArgumentException>(()=>PatternMatching.ConvertTotTuple(null));
            Assert.Throws<ArgumentException>(()=>PatternMatching.ConvertTotTuple(5));
            Assert.Throws<ArgumentException>(()=>PatternMatching.ConvertTotTuple(new string[] { "John", "Paul" }));
        }
    }
}
