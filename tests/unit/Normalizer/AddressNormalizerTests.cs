using FluentAssertions;

using SsiGroup.ProjectUsNormalizer;
using SsiGroup.ProjectUsNormalizer.Models;

using Xunit;

namespace ProjectUsNormalizer.Tests.Unit.Normalizer;

public class AddressNormalizerTests
{
  public static TheoryData<Address, Address> AddressCases = new()
  {
    {
      new Address("101 South West Main Street North", "Suite 101", "Spring Hill", "Tennessee", "12345", "USA"),
      new Address("101 SW MAIN ST N", "STE 101", "SPRING HILL", "TN", "12345", "USA")
    },
    {
      new Address("101 South West Main Street North", "Suite 101", "Spring Hill", "Tennessee", "12345", "US"),
      new Address("101 SW MAIN ST N", "STE 101", "SPRING HILL", "TN", "12345", "US")
    },
    {
      new Address("101 Main Street", City: "Spring Hill", State: "Tennessee", PostalCode: "12345-0123"),
      new Address("101 MAIN ST", City: "SPRING HILL", State: "TN", PostalCode: "12345-0123")
    },
    {
      new Address("Rural route 33 #53BC", City: "Spring Hill", State: "Tennessee", PostalCode: "12345-0123"),
      new Address("RR 33 BOX 53BC", City: "SPRING HILL", State: "TN", PostalCode: "12345-0123")
    },
    {
      new Address("123 Church Street West", City: "@Spring \t Hill", State: "Tennessee", PostalCode: "12345-0123"),
      new Address("123 CHURCH ST W", City: "SPRING HILL", State: "TN", PostalCode: "12345-0123")
    },
    {
      new Address(StreetAddress1: "123    Church Pky Avenue West \n", StreetAddress2: "Suite 101", City: "@Spring \t Hill", State: "Tennessee", PostalCode: "12345-0123"),
      new Address("123 CHURCH PARKWAY AVE W", "STE 101", "SPRING HILL", "TN", "12345-0123")
    }
  };

  [Theory]
  [MemberData(nameof(AddressCases))]
  public void ShouldReturnExpectedNormalizedAddress(Address address, Address expected)
  {
    Address actual = AddressNormalizer.Normalize(address);

    actual.Should().BeEquivalentTo(expected);
  }
}
