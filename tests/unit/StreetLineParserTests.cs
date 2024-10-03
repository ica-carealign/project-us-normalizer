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
      "101 South West Main Thing St North East Apartment 12", new List<StreetComponent>
      {
        new("101", StreetComponentType.PrimaryAddressNumber),
        new("SW", StreetComponentType.Predirectional),
        new("MAIN THING", StreetComponentType.StreetName),
        new("ST", StreetComponentType.Suffix),
        new("NE", StreetComponentType.Postdirectional),
        new("APT", StreetComponentType.SecondaryAddressIdentifier),
        new("12", StreetComponentType.SecondaryAddress)
      }
    },
    {
      "1000 avenue", new List<StreetComponent>
      {
        new("1000", StreetComponentType.PrimaryAddressNumber),
        new("AVENUE", StreetComponentType.StreetName)
      }
    },
    {
      "1001 avenue east", new List<StreetComponent>
      {
        new("1001", StreetComponentType.PrimaryAddressNumber),
        new("AVENUE", StreetComponentType.StreetName),
        new("E", StreetComponentType.Postdirectional)
      }
    },
    {
      "1002 NORTH avenue east", new List<StreetComponent>
      {
        new("1002", StreetComponentType.PrimaryAddressNumber),
        new("NORTH", StreetComponentType.StreetName),
        new("AVE", StreetComponentType.Suffix),
        new("E", StreetComponentType.Postdirectional)
      }
    },
    {
      "1003 west avenue", new List<StreetComponent>
      {
        new("1003", StreetComponentType.PrimaryAddressNumber),
        new("WEST", StreetComponentType.StreetName),
        new("AVE", StreetComponentType.Suffix)
      }
    },
    {
      "1004 south avenue B", new List<StreetComponent>
      {
        new("1004", StreetComponentType.PrimaryAddressNumber),
        new("S", StreetComponentType.Predirectional),
        new("AVENUE B", StreetComponentType.StreetName)
      }
    },
    {
      "1010 North east street", new List<StreetComponent>
      {
        new("1010", StreetComponentType.PrimaryAddressNumber),
        new("N", StreetComponentType.Predirectional),
        new("EAST", StreetComponentType.StreetName),
        new("ST", StreetComponentType.Suffix)
      }
    },
    {
      "1011 NE street", new List<StreetComponent>
      {
        new("1011", StreetComponentType.PrimaryAddressNumber),
        new("NORTHEAST", StreetComponentType.StreetName),
        new("ST", StreetComponentType.Suffix)
      }
    },
    {
      "322 West End Avenue", new List<StreetComponent>
      {
        new("322", StreetComponentType.PrimaryAddressNumber),
        new("W", StreetComponentType.Predirectional),
        new("END", StreetComponentType.StreetName),
        new("AVE", StreetComponentType.Suffix)
      }
    },
    {
      "654 SOUTHEAST FREEWAY NORTH", new List<StreetComponent>
      {
        new("654", StreetComponentType.PrimaryAddressNumber),
        new("SOUTHEAST", StreetComponentType.StreetName),
        new("FWY", StreetComponentType.Suffix),
        new("N", StreetComponentType.Postdirectional)
      }
    },
    // Special cases (country roads/highways)
    {
      "201 COUNTY HIGHWAY 140", new List<StreetComponent>
      {
        new("201", StreetComponentType.PrimaryAddressNumber),
        new("COUNTY HIGHWAY 140", StreetComponentType.StreetName)
      }
    },
    {
      "202 COUNTY HWY 60E", new List<StreetComponent>
      {
        new("202", StreetComponentType.PrimaryAddressNumber),
        new("COUNTY HIGHWAY 60E", StreetComponentType.StreetName)
      }
    },
    {
      "203 CNTY  HWY 20", new List<StreetComponent>
      {
        new("203", StreetComponentType.PrimaryAddressNumber),
        new("COUNTY HIGHWAY 20", StreetComponentType.StreetName)
      }
    },
    {
      "204 CR 395", new List<StreetComponent>
      {
        new("204", StreetComponentType.PrimaryAddressNumber),
        new("COUNTY ROAD 395", StreetComponentType.StreetName)
      }
    },
    {
      "205 cnty rd 33", new List<StreetComponent>
      {
        new("205", StreetComponentType.PrimaryAddressNumber),
        new("COUNTY ROAD 33", StreetComponentType.StreetName)
      }
    },
    {
      "206 California county road 555", new List<StreetComponent>
      {
        new("206", StreetComponentType.PrimaryAddressNumber),
        new("CA COUNTY ROAD 555", StreetComponentType.StreetName)
      }
    },
    {
      "207 st hwy 36", new List<StreetComponent>
      {
        new("207", StreetComponentType.PrimaryAddressNumber),
        new("STATE HIGHWAY 36", StreetComponentType.StreetName)
      }
    },
    // Multiple suffixes should spell out first (and it should be street name) and abbreviate second suffix
    {
      "789 main AVENUE DRIVE", new List<StreetComponent>
      {
        new("789", StreetComponentType.PrimaryAddressNumber),
        new("MAIN AVENUE", StreetComponentType.StreetName),
        new("DR", StreetComponentType.Suffix)
      }
    },
    // Ordinal number street should be street name
    {
      "4513 3rd STREET CIRCLE WEST", new List<StreetComponent>
      {
        new("4513", StreetComponentType.PrimaryAddressNumber),
        new("3RD STREET", StreetComponentType.StreetName),
        new("CIR", StreetComponentType.Suffix),
        new("W", StreetComponentType.Postdirectional)
      }
    },
    // Hyphenated address ranges should keep hyphens
    {
      "112–10 WEST BRONX ROAD", new List<StreetComponent>
      {
        new("112–10", StreetComponentType.PrimaryAddressNumber),
        new("W", StreetComponentType.Predirectional),
        new("BRONX", StreetComponentType.StreetName),
        new("RD", StreetComponentType.Suffix)
      }
    },
    {
      "3145 Highway 431", new List<StreetComponent>
      {
        new("3145", StreetComponentType.PrimaryAddressNumber),
        new("HIGHWAY 431", StreetComponentType.StreetName)
      }
    },
    {
      "1324 New Hampshire", new List<StreetComponent>
      {
        new("1324", StreetComponentType.PrimaryAddressNumber),
        new("NEW HAMPSHIRE", StreetComponentType.StreetName)
      }
    },
    {
      "842 E 1700 S", new List<StreetComponent>
      {
        new("842", StreetComponentType.PrimaryAddressNumber),
        new("E", StreetComponentType.Predirectional),
        new("1700", StreetComponentType.StreetName),
        new("S", StreetComponentType.Postdirectional)
      }
    },
    {
      "11790 Road 39.4", new List<StreetComponent>
      {
        new("11790", StreetComponentType.PrimaryAddressNumber),
        new("ROAD 39.4", StreetComponentType.StreetName)
      }
    },
    {
      "11791 rd 39.4", new List<StreetComponent>
      {
        new("11791", StreetComponentType.PrimaryAddressNumber),
        new("ROAD 39.4", StreetComponentType.StreetName)
      }
    },
    {
      "1325 hwy 412 East", new List<StreetComponent>
      {
        new("1325", StreetComponentType.PrimaryAddressNumber),
        new("HIGHWAY 412", StreetComponentType.StreetName),
        new("E", StreetComponentType.Postdirectional)
      }
    },
    {
      "8820 west 49th. Street", new List<StreetComponent>
      {
        new("8820", StreetComponentType.PrimaryAddressNumber),
        new("W", StreetComponentType.Predirectional),
        new("49TH", StreetComponentType.StreetName),
        new("ST", StreetComponentType.Suffix)
      }
    },
    // Special characters should be removed.
    {
      "999    North    west* Togo ROAD (east)", new List<StreetComponent>
      {
        new("999", StreetComponentType.PrimaryAddressNumber),
        new("NW", StreetComponentType.Predirectional),
        new("TOGO", StreetComponentType.StreetName),
        new("RD", StreetComponentType.Suffix),
        new("E", StreetComponentType.Postdirectional)
      }
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
