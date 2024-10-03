namespace SsiGroup.ProjectUsNormalizer.Constants;

internal static class SpecialCases
{
  /// <summary>
  ///   Special cases mappings, including rural routes, state routes, country roads, etc.
  /// </summary>
  /// <remarks>
  ///   Note that most of the keys and values have spaces before and after to prevent partial matching.
  /// </remarks>
  internal static IReadOnlyDictionary<string, string> Mappings = new Dictionary<string, string>
  {
    { "POST OFFICE ", "PO " }, // POST OFFICE has no leading space
    { " COUNTY HWY ", " COUNTY HIGHWAY " },
    { " COUNTY RD ", " COUNTY ROAD " },
    { " CNTY HIGHWAY ", " COUNTY HIGHWAY " },
    { " CNTY HWY ", " COUNTY HIGHWAY " },
    { " CNTY ROAD ", " COUNTY ROAD " },
    { " CNTY RD ", " COUNTY ROAD " },
    { " CR ", " COUNTY ROAD " },
    { " HIGHWAY FARM TO MARKET ", " FM " },
    { " HWY FARM TO MARKET ", " FM " },
    { " FARM TO MARKET ", " FM " },
    { " HIGHWAY FM ", " FM " },
    { " HWY FM ", " FM " },
    { " GEN ", " GENERAL " },
    { " HIGHWAY CONTRACT NUMBER ", " HC " },
    { " HIGHWAY CONTRACT NO ", " HC " },
    { " HIGHWAY CONTRACT ", " HC " },
    { " HWY CONTRACT NUMBER ", " HC " },
    { " HWY CONTRACT NO ", " HC " },
    { " HWY CONTRACT ", " HC " },
    { " INTERSTATE HWY ", " INTERSTATE " },
    { " I ", " INTERSTATE " },
    { " RANCH RD ", " RANCH ROAD " },
    { " TOWNSHIP RD ", " TOWNSHIP ROAD " },
    { " TSR ", " TOWNSHIP ROAD " },
    { " SR ", " STATE ROAD " },
    { " STATE HWY ", " STATE HIGHWAY " },
    { " STATE RD ", " STATE ROAD " },
    { " STATE RT ", " STATE ROUTE " },
    { " ST HIGHWAY ", " STATE HIGHWAY " },
    { " STATE RTE ", " STATE ROUTE " },
    { " ST HWY ", " STATE HIGHWAY " },
    { " ST ROAD ", " STATE ROAD " },
    { " ST RD ", " STATE ROAD " },
    { " ST ROUTE ", " STATE ROUTE " },
    { " ST RTE ", " STATE ROUTE " },
    { " ST RT ", " STATE ROUTE " },
    { " US HWY ", " US HIGHWAY " },
    { " US ", " US HIGHWAY " },
    { " RTE ", " ROUTE " },
    { " RT ", " ROUTE " }
  };
}
