// Copyright 2017 Krasimir Kostadinov. All rights reserved. Use of this source code is governed by the Apache License 2.0, as found on https://www.apache.org/licenses/LICENSE-2.0

using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace WhatsNewInCS7.Tests
{
    public class LocalMethodsTests
    {
        [Theory]
        [InlineData("John", "Paul", "II")]
        [InlineData("One", "Two", "Three")]
        [InlineData("Angelina", "Jolie", "Pitt")]
        public void TestListNameTupleElements_Should_return_an_IEnnumerable(string firstName, string middleName, string familyName)
        {
            var actualTuple = Tuples.ConvertToTuple(firstName, middleName, familyName);
            var actualCollection = LocalMethods.ListNameTupleElements(new List<(string FirstName, string MiddleName, string FamilyName)>() { actualTuple });
            var actualList = actualCollection.ToList();
            actualList.Count.Should().Be(3, because: "The collection should contain 3 elements - the names from the tuple");
            actualList[0].Should().Be(firstName, because: "The first element should be the first name");
            actualList[1].Should().Be(middleName, because: "The second element should be the middle name");
            actualList[2].Should().Be(familyName, because: "The third element should be the family name");
        }
    }
}
