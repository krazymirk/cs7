// Copyright 2017 Krasimir Kostadinov. All rights reserved. Use of this source code is governed by the Apache License 2.0, as found on https://www.apache.org/licenses/LICENSE-2.0

using FluentAssertions;
using System;
using Xunit;

namespace WhatsNewInCS7.Tests
{

    public class DeconstructionTests
    {
        [Theory]
        [InlineData(2017,10,10)]
        [InlineData(2012,11,2)]
        [InlineData(2001,9,5)]
        [InlineData(1983,7,10)]
        public void TestExtensionDeconstruction_Should_deconstruct_DateTime_to_int_tuple(int year, int month, int day)
        {
            var expectedDate = new DateTime(year, month, day);
            var (actualMonth, actualDay, actualYear) = expectedDate;
            actualDay.Should().Be(expectedDate.Day, because: $"Dates should match, but we have {actualDay} and {expectedDate.Day}");
            actualMonth.Should().Be(expectedDate.Month, because: $"Dates should match, but we have {actualMonth} and {expectedDate.Month}");
            actualYear.Should().Be(expectedDate.Year, because: $"Dates should match, but we have {actualYear} and {expectedDate.Year}");
        }

        [Theory]
        [InlineData("John", "Paul", "II")]
        [InlineData("One", "Two", "Three")]
        [InlineData("Angelina", "Jolie", "Pitt")]
        public void TestPersonDeconstruction_Should_deconstruct_Person_to_string_tuple(string FirstName, string MiddleName, string FamilyName)
        {
            var actualPerson = new Person(FamilyName, MiddleName, FamilyName);
            var (actualFirst, actualMiddle, actualFamily) = actualPerson;
            actualFirst.Should().Be(FirstName, because: $"First name was expected to be {FirstName}, but was {actualFirst}");
            actualMiddle.Should().Be(MiddleName, because: $"Middle name was expected to be {MiddleName}, but was {actualMiddle}");
            actualFamily.Should().Be(FamilyName, because: $"Family name was expected to be {FamilyName}, but was {actualFamily}");
        }
    }
}
