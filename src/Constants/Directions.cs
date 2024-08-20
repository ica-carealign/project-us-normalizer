namespace SsiGroup.ProjectUsNormalizer.Constants;

/// <summary>
///   Street address directions.
/// </summary>
internal static class Directions
{
  /// <summary>
  ///   Directional abbreviations.
  /// </summary>
  internal static IReadOnlyDictionary<string, string> Abbreviations = new Dictionary<string, string>
  {
    { "N", "N" },
    { "N.", "N" },
    { "NORTH", "N" },
    { "S", "S" },
    { "S.", "S" },
    { "SOUTH", "S" },
    { "E", "E" },
    { "E.", "E" },
    { "EAST", "E" },
    { "W", "W" },
    { "W.", "W" },
    { "WEST", "W" },
    { "NE", "NE" },
    { "N.E.", "NE" },
    { "N.E", "NE" },
    { "NE.", "NE" },
    { "NORTHEAST", "NE" },
    { "NORTH-EAST", "NE" },
    { "SE", "SE" },
    { "S.E.", "SE" },
    { "S.E", "SE" },
    { "SE.", "SE" },
    { "SOUTHEAST", "SE" },
    { "SOUTH-EAST", "SE" },
    { "NW", "NW" },
    { "N.W.", "NW" },
    { "N.W", "NW" },
    { "NW.", "NW" },
    { "NORTHWEST", "NW" },
    { "NORTH-WEST", "NW" },
    { "SW", "SW" },
    { "S.W.", "SW" },
    { "S.W", "SW" },
    { "SW.", "SW" },
    { "SOUTHWEST", "SW" },
    { "SOUTH-WEST", "SW" }
  };

  /// <summary>
  ///   Address directional fully spelled out.
  /// </summary>
  internal static IReadOnlyDictionary<string, string> FullySpelledOut = new Dictionary<string, string>
  {
    { "N", "NORTH" },
    { "N.", "NORTH" },
    { "NORTH", "NORTH" },
    { "S", "SOUTH" },
    { "S.", "SOUTH" },
    { "SOUTH", "SOUTH" },
    { "E", "EAST" },
    { "E.", "EAST" },
    { "EAST", "EAST" },
    { "W", "WEST" },
    { "W.", "WEST" },
    { "WEST", "WEST" },
    { "NE", "NORTHEAST" },
    { "N.E.", "NORTHEAST" },
    { "N.E", "NORTHEAST" },
    { "NE.", "NORTHEAST" },
    { "NORTHEAST", "NORTHEAST" },
    { "NORTH-EAST", "NORTHEAST" },
    { "SE", "SOUTHEAST" },
    { "S.E.", "SOUTHEAST" },
    { "S.E", "SOUTHEAST" },
    { "SE.", "SOUTHEAST" },
    { "SOUTHEAST", "SOUTHEAST" },
    { "SOUTH-EAST", "SOUTHEAST" },
    { "NW", "NORTHWEST" },
    { "N.W.", "NORTHWEST" },
    { "N.W", "NORTHWEST" },
    { "NW.", "NORTHWEST" },
    { "NORTHWEST", "NORTHWEST" },
    { "NORTH-WEST", "NORTHWEST" },
    { "SW", "SOUTHWEST" },
    { "S.W.", "SOUTHWEST" },
    { "S.W", "SOUTHWEST" },
    { "SW.", "SOUTHWEST" },
    { "SOUTHWEST", "SOUTHWEST" },
    { "SOUTH-WEST", "SOUTHWEST" }
  };
}
