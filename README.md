# Project US@ Normalizer

C# library to facilitate address normalization in accordance with [Project US@][], the "Unified Specification for Addresses in Health Care".

**NOTE:** This package doesn't validate the existence of an address, it only normalizes fields based on the rules of [Project US@][] specification.

## Usage

### Normalize All Address Fields

```cs
Address address = new (
  StreetAddress1: "123    Church Pky Avenue West \n",
  StreetAddress2: "Suite 101",
  City: "@Spring \t Hill",
  State: "Tennessee",
  PostalCode: "12345-0123"
);
Address normalizedAddress = address.Normalize();

// The output of normalizedAddress:
// new Address("123 CHURCH PARKWAY AVE W", "STE 101", "SPRING HILL", "TN", "12345-0123")
```

### Normalize Individual Address Fields

#### Normalize Street Line

```cs
string streetLine = "1011 South West Main Thing St North East Apartment 280";
string normalizedStreetLine = streetLine.NormalizeStreetLine();

// The output of normalizedStreetLine:
// "1011 SW MAIN THING ST NE APT 280"
```

See [StreetLineNormalizerTests unit tests][] for more examples.

#### Normalize State

```cs
string state = "  \nTennessee";
string normalizedState = state.NormalizeState();

// The output of normalizedState:
// "TN"
```

### Parse Street Line Into Individual Components

[StreetLineParser][] is able to parse a given street line into normalized individual street components.

```cs
string streetLine = "101 South West Main Thing St North East Apartment 12";
IEnumerable<StreetComponent> parsedStreetComponents = StreetLineParser.Parse(streetLine);

// The output of parsedStreetComponents:
// new List<StreetComponent>
// {
//   new("101", StreetComponentType.PrimaryAddressNumber),
//   new("SW", StreetComponentType.Predirectional),
//   new("MAIN THING", StreetComponentType.StreetName),
//   new("ST", StreetComponentType.Suffix),
//   new("NE", StreetComponentType.Postdirectional),
//   new("APT", StreetComponentType.SecondaryAddressIdentifier),
//   new("12", StreetComponentType.SecondaryAddress)
// }
```

## Installation

Install `ProjectUsNormalizer` as a NuGet package, via an IDE package manager, or using the command-line instructions
at [Install-Package ProjectUsNormalizer][].


[Install-Package ProjectUsNormalizer]: https://www.nuget.org/packages/ProjectUsNormalizer/
[Project US@]: https://oncprojectracking.healthit.gov/wiki/pages/viewpage.action?pageId=180486153
[StreetLineNormalizerTests unit tests]: ./tests/unit/Normalizer/StreetLineNormalizerTests.cs
[StreetLineParser]: ./docs/api/SsiGroup.ProjectUsNormalizer/StreetLineParser.md