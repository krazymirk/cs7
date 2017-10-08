using FluentAssertions;
using Xunit;

namespace WhatsNewInCS7.Tests
{
    public class ReferencesTests
    {
        [Theory]
        [InlineData("John", "Paul", "II", "john")]
        [InlineData("One", "Two", "Three", "two")]
        [InlineData("Angelina", "Jolie", "Pitt", "Pitt")]
        public void TestFindTuple_Should_return_a_valid_Tuple(string firstName, string middleName, string familyName, string searchKey)
        {
            var actualTuple = Tuples.ConvertToTuple(firstName, middleName, familyName);
            (string FirstName, string MiddleName, string FamilyName) tupleFound = References.FindTuple(searchKey, new(string FirstName, string MiddleName, string FamilyName)[] { actualTuple });

            tupleFound.FirstName.Should().Be(firstName, because: $"The first name of the found tuple should be {firstName}");
            tupleFound.MiddleName.Should().Be(middleName, because: $"The middle name of the found tuple should be {middleName}");
            tupleFound.FamilyName.Should().Be(familyName, because: $"The family name of the found tuple should be {familyName}");
        }
    }
}
