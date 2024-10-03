namespace SsiGroup.ProjectUsNormalizer.Constants;

/// <summary>
///   Secondary address unit designators.
/// </summary>
internal static class SecondaryUnitDesignators
{
  /// <summary>
  ///   Secondary address unit designator abbreviations.
  /// </summary>
  /// <remarks>
  ///   Taken from Project US@ technical specification:
  ///   <a href="https://oncprojectracking.healthit.gov/wiki/pages/viewpage.action?pageId=180486153" />.
  ///   Table 1: Secondary Address Unit Designators. Page 19.
  /// </remarks>
  public static readonly IReadOnlyDictionary<string, string> Abbreviations = new Dictionary<string, string>
  {
    { "#", "#" },
    { "APT", "APT" },
    { "APARTMENT", "APT" },
    { "BSMT", "BSMT" },
    { "BASEMENT", "BSMT" },
    { "BLDG", "BLDG" },
    { "BUILDING", "BLDG" },
    { "DEPT", "DEPT" },
    { "DEPARTMENT", "DEPT" },
    { "FL", "FL" },
    { "FLOOR", "FL" },
    { "FRNT", "FRNT" },
    { "FRONT", "FRNT" },
    { "HNGR", "HNGR" },
    { "HANGER", "HNGR" },
    { "KEY", "KEY" },
    { "LBBY", "LBBY" },
    { "LOBBY", "LBBY" },
    { "LOT", "LOT" },
    { "LOWR", "LOWR" },
    { "LOWER", "LOWR" },
    { "OFC", "OFC" },
    { "OFFICE", "OFC" },
    { "PH", "PH" },
    { "PENTHOUSE", "PH" },
    { "PIER", "PIER" },
    { "REAR", "REAR" },
    { "RM", "RM" },
    { "ROOM", "RM" },
    { "SIDE", "SIDE" },
    { "SLIP", "SLIP" },
    { "SPC", "SPC" },
    { "SPACE", "SPC" },
    { "STOP", "STOP" },
    { "STE", "STE" },
    { "SUITE", "STE" },
    { "TRLR", "TRLR" },
    { "TRAILER", "TRLR" },
    { "UNIT", "UNIT" },
    { "UPPR", "UPPR" },
    { "UPPER", "UPPR" }
  };

  /// <summary>
  ///   Secondary unit designators that require secondary address.
  /// </summary>
  /// <remarks>
  ///   Taken from Project US@ technical specification:
  ///   <a href="https://oncprojectracking.healthit.gov/wiki/pages/viewpage.action?pageId=180486153" />.
  ///   Table 1: Secondary Address Unit Designators. Page 19.
  /// </remarks>
  public static IReadOnlyList<string> RequireSecondaryAddress = new List<string>
  {
    "#",
    "APARTMENT",
    "APT",
    "BLDG",
    "BUILDING",
    "DEPARTMENT",
    "DEPT",
    "FL",
    "FLOOR",
    "HNGR",
    "HANGER",
    "KEY",
    "LOT",
    "PIER",
    "RM",
    "ROOM",
    "SLIP",
    "SPACE",
    "SPC",
    "STOP",
    "STE",
    "SUITE",
    "TRAILER",
    "TRLR",
    "UNIT"
  };
}
