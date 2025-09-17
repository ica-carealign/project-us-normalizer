using FluentAssertions;

using SsiGroup.ProjectUsNormalizer;
using SsiGroup.ProjectUsNormalizer.Models;

using Xunit;

namespace ProjectUsNormalizer.Tests.Unit;

public class StreetLineParserTests
{
  public static TheoryData<string?, List<StreetComponent>> StreetParsingTestCases = new()
  {
    {
      "101 South West Main Thing St North East Apartment 12", [
        new StreetComponent("101", StreetComponentType.PrimaryAddressNumber),
        new StreetComponent("SW", StreetComponentType.Predirectional),
        new StreetComponent("MAIN THING", StreetComponentType.StreetName),
        new StreetComponent("ST", StreetComponentType.Suffix),
        new StreetComponent("NE", StreetComponentType.Postdirectional),
        new StreetComponent("APT", StreetComponentType.SecondaryAddressIdentifier),
        new StreetComponent("12", StreetComponentType.SecondaryAddress)
      ]
    },
    {
      "1000 avenue", [
        new StreetComponent("1000", StreetComponentType.PrimaryAddressNumber),
        new StreetComponent("AVENUE", StreetComponentType.StreetName)
      ]
    },
    {
      "1001 avenue east", [
        new StreetComponent("1001", StreetComponentType.PrimaryAddressNumber),
        new StreetComponent("AVENUE", StreetComponentType.StreetName),
        new StreetComponent("E", StreetComponentType.Postdirectional)
      ]
    },
    {
      "1002 NORTH avenue east", [
        new StreetComponent("1002", StreetComponentType.PrimaryAddressNumber),
        new StreetComponent("NORTH", StreetComponentType.StreetName),
        new StreetComponent("AVE", StreetComponentType.Suffix),
        new StreetComponent("E", StreetComponentType.Postdirectional)
      ]
    },
    {
      "1003 west avenue", [
        new StreetComponent("1003", StreetComponentType.PrimaryAddressNumber),
        new StreetComponent("WEST", StreetComponentType.StreetName),
        new StreetComponent("AVE", StreetComponentType.Suffix)
      ]
    },
    {
      "1004 south avenue B", [
        new StreetComponent("1004", StreetComponentType.PrimaryAddressNumber),
        new StreetComponent("S", StreetComponentType.Predirectional),
        new StreetComponent("AVENUE B", StreetComponentType.StreetName)
      ]
    },
    {
      "1010 North east street", [
        new StreetComponent("1010", StreetComponentType.PrimaryAddressNumber),
        new StreetComponent("N", StreetComponentType.Predirectional),
        new StreetComponent("EAST", StreetComponentType.StreetName),
        new StreetComponent("ST", StreetComponentType.Suffix)
      ]
    },
    {
      "1011 NE street", [
        new StreetComponent("1011", StreetComponentType.PrimaryAddressNumber),
        new StreetComponent("NORTHEAST", StreetComponentType.StreetName),
        new StreetComponent("ST", StreetComponentType.Suffix)
      ]
    },
    {
      "322 West End Avenue", [
        new StreetComponent("322", StreetComponentType.PrimaryAddressNumber),
        new StreetComponent("W", StreetComponentType.Predirectional),
        new StreetComponent("END", StreetComponentType.StreetName),
        new StreetComponent("AVE", StreetComponentType.Suffix)
      ]
    },
    {
      "654 SOUTHEAST FREEWAY NORTH", [
        new StreetComponent("654", StreetComponentType.PrimaryAddressNumber),
        new StreetComponent("SOUTHEAST", StreetComponentType.StreetName),
        new StreetComponent("FWY", StreetComponentType.Suffix),
        new StreetComponent("N", StreetComponentType.Postdirectional)
      ]
    },
    // Special cases (country roads/highways)
    {
      "201 COUNTY HIGHWAY 140", [
        new StreetComponent("201", StreetComponentType.PrimaryAddressNumber),
        new StreetComponent("COUNTY HIGHWAY 140", StreetComponentType.StreetName)
      ]
    },
    {
      "202 COUNTY HWY 60E", [
        new StreetComponent("202", StreetComponentType.PrimaryAddressNumber),
        new StreetComponent("COUNTY HIGHWAY 60E", StreetComponentType.StreetName)
      ]
    },
    {
      "203 CNTY  HWY 20", [
        new StreetComponent("203", StreetComponentType.PrimaryAddressNumber),
        new StreetComponent("COUNTY HIGHWAY 20", StreetComponentType.StreetName)
      ]
    },
    {
      "204 CR 395", [
        new StreetComponent("204", StreetComponentType.PrimaryAddressNumber),
        new StreetComponent("COUNTY ROAD 395", StreetComponentType.StreetName)
      ]
    },
    {
      "205 cnty rd 33", [
        new StreetComponent("205", StreetComponentType.PrimaryAddressNumber),
        new StreetComponent("COUNTY ROAD 33", StreetComponentType.StreetName)
      ]
    },
    {
      "206 California county road 555", [
        new StreetComponent("206", StreetComponentType.PrimaryAddressNumber),
        new StreetComponent("CA COUNTY ROAD 555", StreetComponentType.StreetName)
      ]
    },
    {
      "207 st hwy 36", [
        new StreetComponent("207", StreetComponentType.PrimaryAddressNumber),
        new StreetComponent("STATE HIGHWAY 36", StreetComponentType.StreetName)
      ]
    },
    // Multiple suffixes should spell out first (and it should be street name) and abbreviate second suffix
    {
      "789 main AVENUE DRIVE", [
        new StreetComponent("789", StreetComponentType.PrimaryAddressNumber),
        new StreetComponent("MAIN AVENUE", StreetComponentType.StreetName),
        new StreetComponent("DR", StreetComponentType.Suffix)
      ]
    },
    // Ordinal number street should be street name
    {
      "4513 3rd STREET CIRCLE WEST", [
        new StreetComponent("4513", StreetComponentType.PrimaryAddressNumber),
        new StreetComponent("3RD STREET", StreetComponentType.StreetName),
        new StreetComponent("CIR", StreetComponentType.Suffix),
        new StreetComponent("W", StreetComponentType.Postdirectional)
      ]
    },
    // Hyphenated address ranges should keep hyphens
    {
      "112–10 WEST BRONX ROAD", [
        new StreetComponent("112–10", StreetComponentType.PrimaryAddressNumber),
        new StreetComponent("W", StreetComponentType.Predirectional),
        new StreetComponent("BRONX", StreetComponentType.StreetName),
        new StreetComponent("RD", StreetComponentType.Suffix)
      ]
    },
    {
      "3145 Highway 431", [
        new StreetComponent("3145", StreetComponentType.PrimaryAddressNumber),
        new StreetComponent("HIGHWAY 431", StreetComponentType.StreetName)
      ]
    },
    {
      "1324 New Hampshire", [
        new StreetComponent("1324", StreetComponentType.PrimaryAddressNumber),
        new StreetComponent("NEW HAMPSHIRE", StreetComponentType.StreetName)
      ]
    },
    {
      "842 E 1700 S", [
        new StreetComponent("842", StreetComponentType.PrimaryAddressNumber),
        new StreetComponent("E", StreetComponentType.Predirectional),
        new StreetComponent("1700", StreetComponentType.StreetName),
        new StreetComponent("S", StreetComponentType.Postdirectional)
      ]
    },
    {
      "11790 Road 39.4", [
        new StreetComponent("11790", StreetComponentType.PrimaryAddressNumber),
        new StreetComponent("ROAD 39.4", StreetComponentType.StreetName)
      ]
    },
    {
      "11791 rd 39.4", [
        new StreetComponent("11791", StreetComponentType.PrimaryAddressNumber),
        new StreetComponent("ROAD 39.4", StreetComponentType.StreetName)
      ]
    },
    {
      "1325 hwy 412 East", [
        new StreetComponent("1325", StreetComponentType.PrimaryAddressNumber),
        new StreetComponent("HIGHWAY 412", StreetComponentType.StreetName),
        new StreetComponent("E", StreetComponentType.Postdirectional)
      ]
    },
    // multiple secondary addresses
    {
      "Unit 3250 412 East Charlotte Ave East Room 120", [
        new StreetComponent("412", StreetComponentType.PrimaryAddressNumber),
        new StreetComponent("E", StreetComponentType.Predirectional),
        new StreetComponent("CHARLOTTE", StreetComponentType.StreetName),
        new StreetComponent("AVE", StreetComponentType.Suffix),
        new StreetComponent("E", StreetComponentType.Postdirectional),
        new StreetComponent("UNIT", StreetComponentType.SecondaryAddressIdentifier),
        new StreetComponent("3250", StreetComponentType.SecondaryAddress),
        new StreetComponent("RM", StreetComponentType.SecondaryAddressIdentifier),
        new StreetComponent("120", StreetComponentType.SecondaryAddress)
      ]
    },
    {
      "Unit 3250 520 2nd Street North East Lobby", [
        new StreetComponent("520", StreetComponentType.PrimaryAddressNumber),
        new StreetComponent("2ND", StreetComponentType.StreetName),
        new StreetComponent("ST", StreetComponentType.Suffix),
        new StreetComponent("NE", StreetComponentType.Postdirectional),
        new StreetComponent("UNIT", StreetComponentType.SecondaryAddressIdentifier),
        new StreetComponent("3250", StreetComponentType.SecondaryAddress),
        new StreetComponent("LBBY", StreetComponentType.SecondaryAddressIdentifier)
      ]
    },
    {
      "Unit 3250 2nd Street North East Lobby", [
        new StreetComponent("2ND", StreetComponentType.StreetName),
        new StreetComponent("ST", StreetComponentType.Suffix),
        new StreetComponent("NE", StreetComponentType.Postdirectional),
        new StreetComponent("UNIT", StreetComponentType.SecondaryAddressIdentifier),
        new StreetComponent("3250", StreetComponentType.SecondaryAddress),
        new StreetComponent("LBBY", StreetComponentType.SecondaryAddressIdentifier)
      ]
    },
    {
      "611MN4 40th. Ave North Apt 243", [
        new StreetComponent("611MN4", StreetComponentType.PrimaryAddressNumber),
        new StreetComponent("40TH", StreetComponentType.StreetName),
        new StreetComponent("AVE", StreetComponentType.Suffix),
        new StreetComponent("N", StreetComponentType.Postdirectional),
        new StreetComponent("APT", StreetComponentType.SecondaryAddressIdentifier),
        new StreetComponent("243", StreetComponentType.SecondaryAddress)
      ]
    },
    {
      "8820 west 49th. Street", [
        new StreetComponent("8820", StreetComponentType.PrimaryAddressNumber),
        new StreetComponent("W", StreetComponentType.Predirectional),
        new StreetComponent("49TH", StreetComponentType.StreetName),
        new StreetComponent("ST", StreetComponentType.Suffix)
      ]
    },
    // Special characters should be removed.
    {
      "999    North    west* Togo ROAD (east)", [
        new StreetComponent("999", StreetComponentType.PrimaryAddressNumber),
        new StreetComponent("NW", StreetComponentType.Predirectional),
        new StreetComponent("TOGO", StreetComponentType.StreetName),
        new StreetComponent("RD", StreetComponentType.Suffix),
        new StreetComponent("E", StreetComponentType.Postdirectional)
      ]
    }
  };

  [Theory]
  [MemberData(nameof(StreetParsingTestCases))]
  public void ShouldCreateExpectedComponents(string? street, List<StreetComponent> expected)
  {
    IEnumerable<StreetComponent> actual = StreetLineParser.Parse(street);

    actual.Should().BeEquivalentTo(expected);
  }
}
